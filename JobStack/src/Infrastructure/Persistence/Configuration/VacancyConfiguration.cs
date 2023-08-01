namespace JobStack.Infrastructure.Persistence.Configuration;

public class VacancyConfiguration : BaseAudiTableEntityConfiguration<Vacancy>
{
    public override void Configure(EntityTypeBuilder<Vacancy> entity)
    {

        entity.Property(p => p.TitleName).IsRequired();
        entity.Property(p => p.Description).HasMaxLength(100).IsRequired(false);
        entity.Property(p => p.Salary).IsRequired(false);
        entity.Property(p => p.Address).IsRequired();
        entity.Property(p => p.Experience).IsRequired(false);
        entity.Property(p => p.ResponsibilityName).IsRequired(false);
        entity.Property(p => p.ResponsibilitiesArray).IsRequired(false);
        entity.Property(p => p.SkillsArray).IsRequired(false);
        entity.Property(p => p.SkillName).IsRequired(false);

        entity.HasOne(h => h.Company)
            .WithMany(x => x.Vacancies)
            .HasForeignKey(x => x.CompanyId);

        entity.HasOne(h => h.Country)
            .WithMany(x => x.Vacancies)
            .HasForeignKey(x => x.CountryId);

        entity.HasOne(h => h.City)
            .WithMany(x => x.Vacancies)
            .HasForeignKey(x => x.CityId);

        entity.HasOne(h => h.Category)
            .WithMany(x => x.Vacancies)
            .HasForeignKey(x => x.CategoryId);

        entity.HasOne(h => h.JobType)
            .WithMany(x => x.Vacancies)
            .HasForeignKey(x => x.JobTypeId);

        base.Configure(entity);
    }
}
