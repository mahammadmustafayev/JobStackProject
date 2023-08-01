namespace JobStack.Infrastructure.Persistence.Configuration;

public class CityConfiguration : BaseAudiTableEntityConfiguration<City>
{
    public override void Configure(EntityTypeBuilder<City> entity)
    {
        entity.Property(p => p.CityName).IsRequired(false);
        base.Configure(entity);
    }
}
