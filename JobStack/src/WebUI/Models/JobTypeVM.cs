using JobStack.WebUI.Models;

namespace WebUI.Models;

public class JobTypeVM : BaseAuditableEntityVM
{
    public string TypeName { get; set; } = null!;
    public ICollection<VacancyVM>? Vacancies { get; set; }
}
