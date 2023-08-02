using JobStack.WebUI.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebUI.Models;

public class CandidateVM : BaseAuditableEntityVM
{
    public string CandidateFirstName { get; set; } = null!;
    public string CandidateLastName { get; set; } = null!;
    public string CandidateEmail { get; set; } = null!;
    public string? CandidateProfession { get; set; }
    public ICollection<ExperienceVM>? Experiences { get; set; }
    public string? Description { get; set; }

    public int? CountryId { get; set; }
    public CountryVM? Country { get; set; }

    public int? CityId { get; set; }
    public CityVM? City { get; set; }

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
