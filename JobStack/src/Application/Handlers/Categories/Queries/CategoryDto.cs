namespace JobStack.Application.Handlers.Categories.Queries;

public class CategoryDto
{
    public int Id { get; set; }
    public bool IsDeleted { get; set; }

    public string CategoryName { get; set; } = null!;
    public string Logo { get; set; }
    [NotMapped]
    public IFormFile Photo { get; set; }
    public virtual ICollection<Vacancy>? Vacancies { get; set; }
}
