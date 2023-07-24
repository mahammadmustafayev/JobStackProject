using JobStack.Domain.Entities;

namespace JobStack.Application.Handlers.Cities.Queries;

public class CityDto
{
    public int Id { get; set; }
    public bool IsDeleted { get; set; }
    public string CityName { get; set; }
    public ICollection<Vacancy>? Vacancies { get; set; }
    public ICollection<Company>? Companies { get; set; }
    public ICollection<Candidate>? Candidates { get; set; }
}
