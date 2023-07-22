

using JobStack.Domain.Common;

namespace JobStack.Domain.Entities;

public class Country:BaseAuditableEntity
{
    public string Name { get; set; }

    public  ICollection<Vacancy>? Vacancies { get; set; }
    public  ICollection<Company>? Companies { get; set; }
    public  ICollection<Candidate>? Candidates { get; set; }

}
