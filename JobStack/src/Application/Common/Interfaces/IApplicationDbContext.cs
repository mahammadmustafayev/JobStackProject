

using JobStack.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace JobStack.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Candidate> Candidates { get; set; }
    DbSet<Company> Companies { get; set; }
    DbSet<City> Cities { get; set; }
    DbSet<Country> Countries { get; set; }
    DbSet<Experience> Experiences { get; set; }
    DbSet<JobApply> JobApplies { get; set; }

    DbSet<Category> Categories { get; set; }
    DbSet<JobType> JobTypes { get; set; }
    DbSet<Vacancy> Vacancies { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
