using JobStack.Domain.Common;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobStack.Domain.Entities;

public class Category:BaseAuditableEntity
{
    public string CategoryName { get; set; } = null!;
    public string Logo { get; set; }
    [NotMapped]
    public IFormFile Photo { get; set; }
    public virtual ICollection<Vacancy>? Vacancies { get; set; }
}
