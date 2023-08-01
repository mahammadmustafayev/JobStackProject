namespace WebUI.Models;

public class JobTypeVM
{
    public string TypeName { get; set; } = null!;
    public ICollection<VacancyVM>? Vacancies { get; set; }
}
