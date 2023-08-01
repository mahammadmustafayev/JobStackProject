namespace JobStack.Application.Handlers.Cities.Validations;

public class CreateCityCommandValidator : AbstractValidator<CreateCityCommand>
{
    public CreateCityCommandValidator()
    {
        RuleFor(c => c.CityName).MaximumLength(120)
            .NotEmpty()
            .WithMessage("City Name is required");
    }
}
