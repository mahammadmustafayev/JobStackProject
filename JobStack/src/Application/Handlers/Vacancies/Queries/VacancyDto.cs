namespace JobStack.Application.Handlers.Vacancies.Queries;

public class VacancyDto
{
    public int Id { get; set; }
    public bool IsDeleted { get; set; }
    public string TitleName { get; set; } = null!;
    public string? Description { get; set; }
    public string? Salary { get; set; }


    public string? Address { get; set; }

    public string? Experience { get; set; }
    public string? ResponsibilityName { get; set; }
    //public string[]? ResponsibilitiesArray { get; set; }
    public string? SkillName { get; set; }
    //public string[]? SkillsArray { get; set; }

    public int? CountryId { get; set; }
    public Country? Country { get; set; }

    public int? CityId { get; set; }
    public City? City { get; set; }

    public int CategoryId { get; set; }
    public int JobTypeId { get; set; }
    public JobType JobType { get; set; }
    public Category Category { get; set; } = null!;

    public int CompanyId { get; set; }
    public Company Company { get; set; } = null!;
    public ICollection<JobApply>? JobApplies { get; set; }

}
