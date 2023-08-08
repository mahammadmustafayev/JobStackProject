namespace JobStack.Infrastructure.Persistence.Configuration;

public class JobApplyConfiguration : BaseAudiTableEntityConfiguration<JobApply>
{
    public override void Configure(EntityTypeBuilder<JobApply> entity)
    {
        entity.Property(p => p.FirstName).IsRequired();
        entity.Property(p => p.LastName).IsRequired();
        entity.Property(p => p.EmailAddress).IsRequired();
        entity.Property(p => p.Description).IsRequired(false);
        entity.Property(p => p.CvFile).IsRequired(false);

        entity.HasOne(h => h.Vacancy)
           .WithMany(h => h.JobApplies)
           .HasForeignKey(x => x.VacancyId)
           .IsRequired(false);

        base.Configure(entity);
    }
}
