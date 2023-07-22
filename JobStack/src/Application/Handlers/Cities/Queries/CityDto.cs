using JobStack.Application.Common.Interfaces;
using JobStack.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobStack.Application.Handlers.Cities.Queries;

public class CityDto:IMapFrom<City>
{
    public int Id { get; set; }
    public bool IsDeleted { get; set; }
    public string CityName { get; set; }
    public ICollection<Vacancy>? Vacancies { get; set; }
    public ICollection<Company>? Companies { get; set; }
    public ICollection<Candidate>? Candidates { get; set; }
}
