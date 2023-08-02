using JobStack.WebUI.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebUI.Models;

public class CategoryVM : BaseAuditableEntityVM
{
    public string CategoryName { get; set; } = null!;
    public string? Logo { get; set; }
    [NotMapped]
    public IFormFile? Photo { get; set; }
    public ICollection<VacancyVM>? Vacancies { get; set; }
}
