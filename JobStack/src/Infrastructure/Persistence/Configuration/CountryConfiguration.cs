namespace JobStack.Infrastructure.Persistence.Configuration;

public class CountryConfiguration : BaseAudiTableEntityConfiguration<Country>
{
    public override void Configure(EntityTypeBuilder<Country> entity)
    {
        entity.Property(p => p.Name).IsRequired();

        base.Configure(entity);
    }
}
