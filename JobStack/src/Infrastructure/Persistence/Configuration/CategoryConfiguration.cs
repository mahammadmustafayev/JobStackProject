

using JobStack.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobStack.Infrastructure.Persistence.Configuration;

public class CategoryConfiguration:BaseAudiTableEntityConfiguration<Category>
{
    public override void Configure(EntityTypeBuilder<Category> entity)
    {
        entity.Property(p => p.CategoryName).HasMaxLength(200).IsRequired();
        entity.Property(p=>p.Logo).IsRequired();
        entity.Property(p=>p.Photo).IsRequired();

        base.Configure(entity);
    }
}
