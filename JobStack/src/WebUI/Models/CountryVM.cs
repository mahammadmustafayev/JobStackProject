using JobStack.WebUI.Models;

namespace WebUI.Models;

public class CountryVM : BaseAuditableEntityVM
{
    public string Name { get; set; } = null!;

    public ICollection<VacancyVM>? Vacancies { get; set; }
    public ICollection<CompanyVM>? Companies { get; set; }
    public ICollection<CandidateVM>? Candidates { get; set; }
}
