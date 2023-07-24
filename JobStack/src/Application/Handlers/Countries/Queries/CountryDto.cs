using JobStack.Domain.Entities;

namespace JobStack.Application.Handlers.Countries.Queries;

public class CountryDto
{
    public int Id { get; set; }
    public bool IsDeleted { get; set; }
    public string Name { get; set; }

    public ICollection<Vacancy>? Vacancies { get; set; }
    public ICollection<Company>? Companies { get; set; }
    public ICollection<Candidate>? Candidates { get; set; }
}
