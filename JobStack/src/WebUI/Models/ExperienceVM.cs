namespace WebUI.Models;

public class ExperienceVM
{
    public string ExperienceName { get; set; } = null!;
    public string? ExperienceDescription { get; set; }

    public DateTime? ExperienceStartYear { get; set; }

    public DateTime? ExperienceEndYear { get; set; }

    public int CandidateId { get; set; }
    public CandidateVM Candidate { get; set; } = null!;
}
