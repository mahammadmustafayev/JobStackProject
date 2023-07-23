

using FluentValidation;
using JobStack.Application.Handlers.JobApplies.Commands.CreateJobApply;

namespace JobStack.Application.Handlers.JobApplies.Validations;

public class CreateJobApplyCommandValidator:AbstractValidator<CreateJobApplyCommand>
{
	public CreateJobApplyCommandValidator()
	{
		RuleFor(j=>j.EmailAddress).NotEmpty();	
		RuleFor(j=>j.FirstName).NotEmpty();	
		RuleFor(j=>j.LastName).NotEmpty();	
		RuleFor(j=>j.Description);
		RuleFor(j=>j.CvFile).NotEmpty();
	}
}
