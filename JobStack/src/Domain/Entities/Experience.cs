namespace JobStack.Domain.Entities;

public class Experience : BaseAuditableEntity
{
    public string ExperienceName { get; set; } = null!;
    public string? ExperienceDescription { get; set; }

    public DateTime? ExperienceStartYear { get; set; }

    public DateTime? ExperienceEndYear { get; set; }


    public int CandidateId { get; set; }
    public Candidate Candidate { get; set; } = null!;
}
