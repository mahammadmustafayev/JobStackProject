

using JobStack.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobStack.Infrastructure.Persistence.Configuration;

public class CompanyConfiguration : BaseAudiTableEntityConfiguration<Company>
{
    public override void Configure(EntityTypeBuilder<Company> entity)
    {
        entity.Property(p => p.CompanyName).IsRequired();
        entity.Property(p => p.Description).IsRequired(false);
        entity.Property(p => p.Founded).IsRequired(false);
        entity.Property(p => p.NumberOfEmployees).IsRequired(false);
        entity.Property(p => p.CompanyEmail).IsRequired(false);
        entity.Property(p => p.CompanySite).IsRequired(false);
        entity.Property(p => p.CompanyLogo).IsRequired(false);

        entity.HasOne(h => h.Country)
           .WithMany(h => h.Companies)
           .HasForeignKey(x => x.CountryId)
           .IsRequired(false);

        entity.HasOne(h => h.City)
           .WithMany(h => h.Companies)
           .HasForeignKey(x => x.CityId)
           .IsRequired(false);

        base.Configure(entity);
    }
}
