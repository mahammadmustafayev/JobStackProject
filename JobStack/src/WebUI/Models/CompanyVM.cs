using JobStack.WebUI.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebUI.Models;

public class CompanyVM : BaseAuditableEntityVM
{
    public string CompanyName { get; set; } = null!;


    public string? Description { get; set; }


    public DateTime? Founded { get; set; }
    public int? NumberOfEmployees { get; set; }

    public int? CountryId { get; set; }
    public CountryVM? Country { get; set; }

    public int? CityId { get; set; }
    public CityVM? City { get; set; }

    public string CompanyEmail { get; set; } = null!;
    public string? CompanySite { get; set; }

    public string? CompanyLogo { get; set; }
    [NotMapped]
    public IFormFile? CompanyUrl { get; set; }

    public ICollection<VacancyVM> Vacancies { get; set; }
    public AppUserVM? CompanyUser { get; set; }

}
