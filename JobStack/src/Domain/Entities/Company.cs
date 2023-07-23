

using JobStack.Domain.Common;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobStack.Domain.Entities;

public class Company:BaseAuditableEntity
{
    public string CompanyName { get; set; } = null!;

    
    public string? Description { get; set; }

    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy}")]
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

    public  ICollection<Vacancy> Vacancies { get; set; }
}
