namespace JobStack.Application.Handlers.Companies.Queries;

public class CompanyDto
{
    public int Id { get; set; }
    public bool IsDeleted { get; set; }

    public string CompanyName { get; set; } = null!;


    public string? Description { get; set; }


    public DateTime? Founded { get; set; }
    public int? NumberOfEmployees { get; set; }

    public int? CountryId { get; set; }
    public Country? Country { get; set; }

    public int? CityId { get; set; }
    public City? City { get; set; }

    public string? CompanyEmail { get; set; }
    public string? CompanySite { get; set; }

    public string CompanyLogo { get; set; }
    [NotMapped]
    public IFormFile CompanyUrl { get; set; }

    public ICollection<Vacancy> Vacancies { get; set; }
}
