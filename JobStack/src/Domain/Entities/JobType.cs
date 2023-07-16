

using JobStack.Domain.Common;

namespace JobStack.Domain.Entities;

public class JobType:BaseAuditableEntity
{
    public string TypeName { get; set; }
    public virtual ICollection<Vacancy>? Vacancies { get; set; }
}
