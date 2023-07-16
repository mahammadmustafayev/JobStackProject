

using JobStack.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace JobStack.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Category> Categories { get; set; }
    DbSet<JobType> JobTypes { get; set; }
    DbSet<Vacancy> Vacancies { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken=default);
}
