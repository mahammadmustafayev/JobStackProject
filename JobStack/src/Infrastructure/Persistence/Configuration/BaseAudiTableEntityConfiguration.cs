namespace JobStack.Infrastructure.Persistence.Configuration;

public class BaseAudiTableEntityConfiguration<T> : IEntityTypeConfiguration<T>
             where T : BaseAuditableEntity
{
    public virtual void Configure(EntityTypeBuilder<T> entity)
    {
        entity.Property(p => p.Id).IsRequired();
        entity.Property(p => p.IsDeleted).IsRequired();
        entity.Property(p => p.Created).IsRequired();
        entity.Property(p => p.CreatedBy).HasMaxLength(150).IsRequired();

        entity.Property(p => p.LastModified).IsRequired(false);
        entity.Property(p => p.LastModifiedBy).HasMaxLength(150).IsRequired(false);
    }
}
