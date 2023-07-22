using FluentValidation;
using JobStack.Application.Handlers.Cities.Commands.UpdateCity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobStack.Application.Handlers.Cities.Validations;

public class UpdateCityCommandValidator:AbstractValidator<UpdateCityCommand>
{
	public UpdateCityCommandValidator()
	{
		RuleFor(c=>c.CityId).NotEmpty().WithMessage("CityId is required");
		RuleFor(c => c.CityName).MaximumLength(120).NotEmpty().WithMessage("City Name is required");
	}
}
