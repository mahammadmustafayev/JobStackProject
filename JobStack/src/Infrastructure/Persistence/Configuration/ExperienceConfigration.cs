

using JobStack.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobStack.Infrastructure.Persistence.Configuration;

public class ExperienceConfigration:BaseAudiTableEntityConfiguration<Experience>
{
    public override void Configure(EntityTypeBuilder<Experience> entity)
    {
        entity.Property(p => p.ExperienceName).IsRequired();
        entity.Property(p => p.ExperienceDescription).IsRequired(false);
        entity.Property(p => p.ExperienceStartYear).IsRequired(false);
        entity.Property(p => p.ExperienceEndYear).IsRequired(false);

        entity.HasOne(h => h.Candidate)
           .WithMany(h => h.Experiences)
           .HasForeignKey(x => x.CandidateId)
           .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.NoAction)
           .IsRequired();

        base.Configure(entity);
    }
}
