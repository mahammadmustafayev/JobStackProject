using System.ComponentModel.DataAnnotations.Schema;
using WebUI.Models;

namespace JobStack.WebUI.DTOs.Vacancy;

public class VacancyUpdateDto
{
    public int VacancyId { get; set; }
    public string TitleName { get; set; } = null!;
    public string? Description { get; set; }
    public string? Salary { get; set; }


    public string? Address { get; set; }

    public string? Experience { get; set; }
    public string? ResponsibilityName { get; set; }
    [NotMapped]
    public string[]? ResponsibilitiesArray { get; set; }
    public string? SkillName { get; set; }
    [NotMapped]
    public string[]? SkillsArray { get; set; }

    public int? CountryId { get; set; }

    public int? CityId { get; set; }

    public int CategoryId { get; set; }
    public CountryVM? Country { get; set; }
    public CityVM? City { get; set; }
    public JobTypeVM? JobType { get; set; }


    public CategoryVM? Category { get; set; }

    public int JobTypeId { get; set; }
}
