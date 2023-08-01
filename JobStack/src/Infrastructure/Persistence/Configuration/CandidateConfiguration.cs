



namespace JobStack.Infrastructure.Persistence.Configuration;

public class CandidateConfiguration : BaseAudiTableEntityConfiguration<Candidate>
{
    public override void Configure(EntityTypeBuilder<Candidate> entity)
    {
        entity.Property(p => p.CandidateFirstName).IsRequired();
        entity.Property(p => p.CandidateLastName).IsRequired();
        entity.Property(p => p.CandidateEmail).IsRequired();
        entity.Property(p => p.CandidateProfession).IsRequired(false);
        entity.Property(p => p.Experiences).IsRequired(false);
        entity.Property(p => p.Description).IsRequired(false);

        entity.Property(p => p.CandidateSkillName).IsRequired(false);
        //entity.Property(p => p.CandidateSkillsArray).IsRequired();
        entity.Property(p => p.CandidateCV).IsRequired(false);
        entity.Property(p => p.CandidateProfilImage).IsRequired(false);

        entity.HasOne(h => h.Country)
           .WithMany(h => h.Candidates)
           .HasForeignKey(x => x.CountryId)
           .IsRequired(false);

        entity
           .HasOne(h => h.City)
           .WithMany(h => h.Candidates)
           .HasForeignKey(x => x.CityId)
           .IsRequired(false);

        base.Configure(entity);
    }
}
