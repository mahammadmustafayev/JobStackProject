namespace JobStack.Infrastructure.Persistence.Configuration;

public class JobTypeConfiguration : BaseAudiTableEntityConfiguration<JobType>
{
    public override void Configure(EntityTypeBuilder<JobType> entity)
    {
        entity.Property(p => p.TypeName).IsRequired();

        base.Configure(entity);
    }
}
