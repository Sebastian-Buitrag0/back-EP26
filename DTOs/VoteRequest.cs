using System.ComponentModel.DataAnnotations;

namespace BackEP26.DTOs;

public class VoteRequest
{
    [Required] public string IdToken { get; set; } = string.Empty;
    [Required] public int CandidatoId { get; set; }
    [Required] public string DeviceId { get; set; } = string.Empty;
    [Required] public string RecaptchaToken { get; set; } = string.Empty;

    // Fecha de nacimiento para determinar si el voto es honorario (menor de 18)
    [Required] public DateOnly BirthDate { get; set; }
}
