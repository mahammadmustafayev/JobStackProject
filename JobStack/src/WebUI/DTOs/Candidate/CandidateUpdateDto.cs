namespace JobStack.WebUI.DTOs.Candidate;

public class CandidateUpdateDto
{
    public int CandidateId { get; set; }
    public string CandidateFirstName { get; set; } = null!;
    public string CandidateLastName { get; set; } = null!;
    public string CandidateEmail { get; set; } = null!;
    public string? CandidateProfession { get; set; }
    public string? Description { get; set; }

    public int? CountryId { get; set; }
    //public CountryVM? Country { get; set; }

    public int? CityId { get; set; }
    //public CityVM? City { get; set; }

    public string? CandidateSkillName { get; set; }
    //[NotMapped]
    //public string[]? CandidateSkillsArray { get; set; }

    public string? CandidateCV { get; set; }
    public string? CandidateProfilImage { get; set; }
    //public AppUserVM? CandidateUser { get; set; }

}
