namespace JobStack.Application.Handlers.Countries.Validations;

public class CreateCountryCommandValidator : AbstractValidator<CreateCountryCommand>
{
    public CreateCountryCommandValidator()
    {
        RuleFor(c => c.CountryName).MaximumLength(120)
            .NotEmpty()
            .WithMessage("Country Name is required");
    }
}
