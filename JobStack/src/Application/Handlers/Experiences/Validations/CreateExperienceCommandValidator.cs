using FluentValidation;
using JobStack.Application.Handlers.Experiences.Commands.CreateExperience;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobStack.Application.Handlers.Experiences.Validations;

public class CreateExperienceCommandValidator:AbstractValidator<CreateExperienceCommand>
{
	public CreateExperienceCommandValidator()
	{
		RuleFor(e=>e.ExperienceName).NotEmpty().WithMessage("Experience Name is required");
		RuleFor(e => e.ExperienceDescription);
		RuleFor(e => e.ExperienceEndYear);
		RuleFor(e => e.ExperienceStartYear);
	}
}
