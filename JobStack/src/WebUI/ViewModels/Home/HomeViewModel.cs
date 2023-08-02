using WebUI.Models;

namespace JobStack.WebUI.ViewModels.Home;

public class HomeViewModel
{
    public List<CategoryVM> Categories { get; set; }
    public List<VacancyVM> Vacancies { get; set; }
    public List<CompanyVM> Companies { get; set; }
}
