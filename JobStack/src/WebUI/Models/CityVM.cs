namespace WebUI.Models;
public class CityVM
{
    public string? CityName { get; set; }
    public ICollection<VacancyVM>? Vacancies { get; set; }
    public ICollection<CompanyVM>? Companies { get; set; }
    public ICollection<CandidateVM>? Candidates { get; set; }
}
