

using FluentValidation;
using JobStack.Application.Handlers.JobApplies.Commands.UpdateJobApply;

namespace JobStack.Application.Handlers.JobApplies.Validations;

public class UpdateJobApplyCommandValidator:AbstractValidator<UpdateJobApplyCommand>
{
	public UpdateJobApplyCommandValidator()
	{
		RuleFor(j=>j.JobApplyId).NotEmpty();
        RuleFor(j => j.EmailAddress).NotEmpty();
        RuleFor(j => j.FirstName).NotEmpty();
        RuleFor(j => j.LastName).NotEmpty();
        RuleFor(j => j.Description);
        RuleFor(j => j.CvFile).NotEmpty();
    }
}
