using JobStack.Application.Common.Interfaces;
using JobStack.Domain.Entities;
using JobStack.Infrastructure.Identity;
using JobStack.Infrastructure.Persistence.Interceptors;
using JobStack.Infrastructure.Seeds;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
{
    private readonly AuditableEntitySaveChangesInterceptor _interceptor;

    public DbSet<Category> Categories { get   ; set   ; }
    public DbSet<JobType> JobTypes { get   ; set   ; }
    public DbSet<Vacancy> Vacancies { get   ; set   ; }
    public DbSet<Candidate> Candidates { get   ; set   ; }
    public DbSet<City> Cities { get   ; set   ; }
    public DbSet<Country> Countries { get   ; set   ; }
    public DbSet<Experience> Experiences { get   ; set   ; }
    public DbSet<Company> Companies { get   ; set   ; }
    public DbSet<JobApply> JobApplies { get   ; set   ; }

    public ApplicationDbContext(
        DbContextOptions<ApplicationDbContext> options,
        AuditableEntitySaveChangesInterceptor interceptor):base(options)
    {
        _interceptor = interceptor;
    }

 

    

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
       

        base.OnModelCreating(builder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(_interceptor);
    }

}
