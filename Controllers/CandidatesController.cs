using BackEP26.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEP26.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CandidatesController(AppDbContext db) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var candidates = await db.Candidates
            .OrderBy(c => c.DisplayOrder)
            .ThenBy(c => c.Name)
            .Select(c => new
            {
                c.Id,
                c.Name,
                c.Party,
                c.Coalition,
                c.VicePresident,
                c.DisplayOrder,
                PhotoUrl = string.IsNullOrEmpty(c.PhotoUrl)
                    ? ""
                    : $"/api/photos/{c.PhotoUrl}"
            })
            .ToListAsync();

        return Ok(candidates);
    }
}
