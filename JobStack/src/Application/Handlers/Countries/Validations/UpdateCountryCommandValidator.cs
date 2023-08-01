namespace JobStack.Application.Handlers.Countries.Validations;

public class UpdateCountryCommandValidator : AbstractValidator<UpdateCountryCommand>
{
    public UpdateCountryCommandValidator()
    {
        RuleFor(c => c.CountryId).NotEmpty().WithMessage("CountryId is required");

        RuleFor(c => c.CountryName).MaximumLength(120)
            .NotEmpty()
            .WithMessage("Country Name is required");
    }
}
