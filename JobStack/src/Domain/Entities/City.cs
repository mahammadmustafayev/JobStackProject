

using JobStack.Domain.Common;

namespace JobStack.Domain.Entities;

public class City:BaseAuditableEntity
{
    public string? CityName { get; set; }
    public  ICollection<Vacancy>? Vacancies { get; set; }
    public  ICollection<Company>? Companies { get; set; }
    public  ICollection<Candidate>? Candidates { get; set; }


}
