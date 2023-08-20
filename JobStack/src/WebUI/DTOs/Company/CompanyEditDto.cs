using WebUI.Models;

namespace JobStack.WebUI.DTOs.Company;

public class CompanyEditDto
{
    public int CompanyId { get; set; }
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
    public IFormFile? CompanyUrl { get; set; }
}
