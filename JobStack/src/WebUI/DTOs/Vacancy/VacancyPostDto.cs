using WebUI.Models;

namespace JobStack.WebUI.DTOs.Vacancy;

public class VacancyPostDto
{
    public string TitleName { get; set; } = null!;
    public string? Description { get; set; }
    public string? Salary { get; set; }


    public string? Address { get; set; }

    public string? Experience { get; set; }
    public string? ResponsibilityName { get; set; }
    public string? SkillName { get; set; }
    public int? CountryId { get; set; }

    public CountryVM? Country { get; set; }

    public int? CityId { get; set; }
    public CityVM? City { get; set; }

    public int CategoryId { get; set; }

    public int JobTypeId { get; set; }

    public JobTypeVM JobType { get; set; }


    public CategoryVM Category { get; set; } = null!;

    public int CompanyId { get; set; }
    public CompanyVM Company { get; set; } = null!;
}
