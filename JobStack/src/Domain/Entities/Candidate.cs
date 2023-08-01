namespace JobStack.Domain.Entities;

public class Candidate : BaseAuditableEntity
{
    public string CandidateFirstName { get; set; } = null!;
    public string CandidateLastName { get; set; } = null!;
    public string CandidateEmail { get; set; } = null!;
    public string? CandidateProfession { get; set; }

    // collection experience
    public ICollection<Experience>? Experiences { get; set; }
    public string? Description { get; set; }

    public int? CountryId { get; set; }
    public Country? Country { get; set; }

    public int? CityId { get; set; }
    public City? City { get; set; }

    public string? CandidateSkillName { get; set; }
    [NotMapped]
    public string[]? CandidateSkillsArray { get; set; }

    public string? CandidateCV { get; set; }
    [NotMapped]
    public IFormFile? CandidateCVUrl { get; set; }

    public string? CandidateProfilImage { get; set; }
    [NotMapped]
    public IFormFile? CandidateProfileUrl { get; set; }
}
