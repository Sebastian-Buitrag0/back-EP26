using System.Security.Cryptography;
using System.Text;
using BackEP26.Data;
using BackEP26.DTOs;
using BackEP26.Hubs;
using BackEP26.Models;
using BackEP26.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace BackEP26.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VotesController(
    AppDbContext db,
    GoogleTokenService googleTokenService,
    RecaptchaService recaptchaService,
    IHubContext<ResultsHub> hub) : ControllerBase
{
    [HttpPost]
    [EnableRateLimiting("vote")]
    public async Task<IActionResult> Cast([FromBody] VoteRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        // 1. Verificar reCAPTCHA (anti-bots)
        var isHuman = await recaptchaService.VerifyAsync(request.RecaptchaToken);
        if (!isHuman)
            return StatusCode(429, new { message = "Verificación anti-bot fallida." });

        // 2. Validar token de Google y obtener sub
        string googleSub;
        try
        {
            googleSub = await googleTokenService.ValidateAndGetSubAsync(request.IdToken);
        }
        catch
        {
            return Unauthorized(new { message = "Token de Google inválido." });
        }

        // 3. Verificar que el candidato existe
        var exists = await db.Candidates.AnyAsync(c => c.Id == request.CandidatoId);
        if (!exists)
            return BadRequest(new { message = "Candidato no encontrado." });

        // 4. Calcular edad y determinar si el voto es honorario
        var today = DateOnly.FromDateTime(DateTime.UtcNow);
        var age = today.Year - request.BirthDate.Year;
        if (request.BirthDate > today.AddYears(-age)) age--;

        if (age < 5 || age > 120)
            return BadRequest(new { message = "Fecha de nacimiento inválida." });

        var isHonorary = age < 18;

        // 5. Hash de googleSub
        var googleSubHash = Hash(googleSub);

        // 6. Verificar Google (1 cuenta = 1 voto)
        if (await db.Votes.AnyAsync(v => v.GoogleSubHash == googleSubHash))
            return Conflict(new { message = "Ya registraste tu voto con esta cuenta de Google." });

        // 7. Verificar DeviceId (1 dispositivo = 1 voto)
        if (await db.Votes.AnyAsync(v => v.DeviceId == request.DeviceId))
            return Conflict(new { message = "Ya registraste tu voto desde este dispositivo." });

        // 8. Guardar voto (IP se registra solo para auditoría, no bloquea)
        var ip = GetClientIp();
        db.Votes.Add(new Vote
        {
            CandidateId = request.CandidatoId,
            GoogleSubHash = googleSubHash,
            DeviceId = request.DeviceId,
            IpAddress = ip,
            IsHonorary = isHonorary
        });

        await db.SaveChangesAsync();

        // 10. Notificar a todos los clientes conectados vía SignalR
        await hub.Clients.All.SendAsync("ResultsUpdated", await BuildSummaryAsync());

        return Ok(new
        {
            message = isHonorary
                ? "¡Voto honorario registrado! Tu participación es muy importante."
                : "¡Voto registrado con éxito!",
            isHonorary
        });
    }

    [HttpGet("results")]
    public async Task<ActionResult<ResultsSummaryDto>> Results()
    {
        return Ok(await BuildSummaryAsync());
    }

    private async Task<ResultsSummaryDto> BuildSummaryAsync()
    {
        var candidates = await db.Candidates
            .Select(c => new
            {
                c.Id,
                c.Name,
                Regular = c.Votes.Count(v => !v.IsHonorary),
                Honorary = c.Votes.Count(v => v.IsHonorary)
            })
            .ToListAsync();

        int totalRegular = candidates.Sum(c => c.Regular);
        int totalHonorary = candidates.Sum(c => c.Honorary);

        var results = candidates
            .OrderByDescending(c => c.Regular)
            .Select(c => new VoteResultDto
            {
                CandidateId = c.Id,
                CandidateName = c.Name,
                Votes = c.Regular,
                Percentage = totalRegular == 0 ? 0 : (int)Math.Round(c.Regular * 100.0 / totalRegular),
                HonoraryVotes = c.Honorary,
                HonoraryPercentage = totalHonorary == 0 ? 0 : (int)Math.Round(c.Honorary * 100.0 / totalHonorary)
            })
            .ToList();

        return new ResultsSummaryDto
        {
            Results = results,
            TotalVotes = totalRegular,
            TotalHonoraryVotes = totalHonorary
        };
    }

    private string GetClientIp()
    {
        var forwarded = HttpContext.Request.Headers["X-Forwarded-For"].FirstOrDefault();
        if (!string.IsNullOrEmpty(forwarded))
            return forwarded.Split(',')[0].Trim();
        return HttpContext.Connection.RemoteIpAddress?.ToString() ?? "unknown";
    }

    private static string Hash(string input)
    {
        var bytes = SHA256.HashData(Encoding.UTF8.GetBytes(input));
        return Convert.ToHexString(bytes).ToLowerInvariant();
    }
}
