using FluentValidation;
using JobStack.Application.Handlers.Countries.Commands.CreateCountry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobStack.Application.Handlers.Countries.Validations;

public class CreateCountryCommandValidator:AbstractValidator<CreateCountryCommand>
{
	public CreateCountryCommandValidator()
	{
		RuleFor(c=>c.CountryName).MaximumLength(120)
			.NotEmpty()
			.WithMessage("Country Name is required");
	}
}
