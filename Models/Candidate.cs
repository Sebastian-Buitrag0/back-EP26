namespace BackEP26.Models;

public class Candidate
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Party { get; set; } = string.Empty;
    public string PhotoUrl { get; set; } = string.Empty;
    public string? Coalition { get; set; }
    public string? VicePresident { get; set; }
    public int DisplayOrder { get; set; } = 99;
    public ICollection<Vote> Votes { get; set; } = [];
}
