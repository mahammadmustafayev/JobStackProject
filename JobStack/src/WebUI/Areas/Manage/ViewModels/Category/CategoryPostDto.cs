namespace JobStack.WebUI.Areas.Manage.ViewModels.Category;

public class CategoryPostDto
{
    public string CategoryName { get; set; }
    public IFormFile Photo { get; set; }
    public string? Logo { get; set; }
}
