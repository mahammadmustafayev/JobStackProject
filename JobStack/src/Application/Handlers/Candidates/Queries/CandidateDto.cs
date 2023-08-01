

namespace JobStack.Application.Handlers.Candidates.Queries;

public class CandidateDto
{
    public int Id { get; set; }
    public bool IsDeleted { get; set; }

    public string CandidateFirstName { get; set; } = null!;
    public string CandidateLastName { get; set; } = null!;
    public string CandidateEmail { get; set; } = null!;
    public string CandidateProfession { get; set; } = null!;

    // collection experience
    public ICollection<Experience>? Experiences { get; set; }
    public string? Description { get; set; }

    //public int? CountryId { get; set; }
    public Country? Country { get; set; }

    //public int? CityId { get; set; }
    public City? City { get; set; }

    public string CandidateSkillName { get; set; } = null!;
    [NotMapped]
    public string[] CandidateSkillsArray { get; set; } = null!;

    public string CandidateCV { get; set; } = null!;
    [NotMapped]
    public IFormFile CandidateCVUrl { get; set; } = null!;

    public string? CandidateProfilImage { get; set; }
    [NotMapped]
    public IFormFile? CandidateProfileUrl { get; set; }
}
