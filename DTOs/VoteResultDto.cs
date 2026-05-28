namespace BackEP26.DTOs;

public class VoteResultDto
{
    public int CandidateId { get; set; }
    public string CandidateName { get; set; } = string.Empty;

    // Votos de mayores de edad (cuentan en el resultado oficial)
    public int Votes { get; set; }
    public int Percentage { get; set; }

    // Votos honorarios (menores de edad)
    public int HonoraryVotes { get; set; }
    public int HonoraryPercentage { get; set; }
}

public class ResultsSummaryDto
{
    public List<VoteResultDto> Results { get; set; } = [];
    public int TotalVotes { get; set; }
    public int TotalHonoraryVotes { get; set; }
}
