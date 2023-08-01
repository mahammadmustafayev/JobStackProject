namespace JobStack.Domain.Entities;

public class JobType : BaseAuditableEntity
{
    public string TypeName { get; set; } = null!;
    public ICollection<Vacancy>? Vacancies { get; set; }
}
