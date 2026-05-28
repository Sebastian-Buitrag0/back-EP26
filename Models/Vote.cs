namespace BackEP26.Models;

public class Vote
{
    public int Id { get; set; }
    public int CandidateId { get; set; }
    public Candidate Candidate { get; set; } = null!;
    public string GoogleSubHash { get; set; } = string.Empty;
    public string DeviceId { get; set; } = string.Empty;
    public string IpAddress { get; set; } = string.Empty;
    public bool IsHonorary { get; set; }
    public DateTime VotedAt { get; set; } = DateTime.UtcNow;
}
