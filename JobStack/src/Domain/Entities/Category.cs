namespace JobStack.Domain.Entities;

public class Category : BaseAuditableEntity
{
    public string CategoryName { get; set; } = null!;
    public string? Logo { get; set; }
    [NotMapped]
    public IFormFile? Photo { get; set; }
    public ICollection<Vacancy>? Vacancies { get; set; }
}
