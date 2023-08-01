namespace JobStack.Application.Handlers.Experiences.Validations;

public class CreateExperienceCommandValidator : AbstractValidator<CreateExperienceCommand>
{
    public CreateExperienceCommandValidator()
    {
        RuleFor(e => e.ExperienceName).NotEmpty().WithMessage("Experience Name is required");
        RuleFor(e => e.ExperienceDescription).NotNull();
        RuleFor(e => e.ExperienceEndYear).NotNull();
        RuleFor(e => e.ExperienceStartYear).NotNull();
    }
}
