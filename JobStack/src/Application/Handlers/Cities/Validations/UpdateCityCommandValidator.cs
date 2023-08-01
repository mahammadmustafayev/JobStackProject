namespace JobStack.Application.Handlers.Cities.Validations;

public class UpdateCityCommandValidator : AbstractValidator<UpdateCityCommand>
{
    public UpdateCityCommandValidator()
    {
        RuleFor(c => c.CityId).NotEmpty().WithMessage("CityId is required");
        RuleFor(c => c.CityName).MaximumLength(120).NotEmpty().WithMessage("City Name is required");
    }
}
