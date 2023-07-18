

using JobStack.Domain.Common;

namespace JobStack.Domain.Entities;

public class Country:BaseAuditableEntity
{
    public string Name { get; set; }

    public virtual ICollection<Vacancy>? Vacancies { get; set; }
    public virtual ICollection<Company>? Companies { get; set; }
    public virtual ICollection<Candidate>? Candidates { get; set; }

}
