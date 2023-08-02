using JobStack.WebUI.Models;

namespace WebUI.Models;

public class ExperienceVM : BaseAuditableEntityVM
{
    public string ExperienceName { get; set; } = null!;
    public string? ExperienceDescription { get; set; }

    public DateTime? ExperienceStartYear { get; set; }

    public DateTime? ExperienceEndYear { get; set; }

    public int CandidateId { get; set; }
    public CandidateVM Candidate { get; set; } = null!;
}
