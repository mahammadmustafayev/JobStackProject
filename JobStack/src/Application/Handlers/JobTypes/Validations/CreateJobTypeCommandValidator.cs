

using FluentValidation;
using JobStack.Application.Handlers.JobTypes.Commands.CreateJobType;

namespace JobStack.Application.Handlers.JobTypes.Validations;

public class CreateJobTypeCommandValidator:AbstractValidator<CreateJobTypeCommand>
{
	public CreateJobTypeCommandValidator()
	{
        RuleFor(c => c.TypeName).MaximumLength(120)
            .NotEmpty()
            .WithMessage("Type Name is required");
    }
}
