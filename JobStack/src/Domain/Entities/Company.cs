

using JobStack.Domain.Common;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobStack.Domain.Entities;

public class Company:BaseAuditableEntity
{
    public string ComapnyName { get; set; } = null!;

    public string Address { get; set; }
    public string Description { get; set; }

    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy}")]
    public DateTime Founded { get; set; }
    public int NumberOdEmployees { get; set; }

    public string? CompanyEmail { get; set; }
    public string? CompanySite { get; set; }

    public string? CompanyLogo { get; set; }
    [NotMapped]
    public IFormFile? CompanyUrl { get; set; }

    public virtual ICollection<Vacancy> Vacancies { get; set; }
}
