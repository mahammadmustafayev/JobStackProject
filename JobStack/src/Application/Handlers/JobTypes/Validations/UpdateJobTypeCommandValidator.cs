﻿

using FluentValidation;
using JobStack.Application.Handlers.JobApplies.Commands.CreateJobApply;
using JobStack.Application.Handlers.JobTypes.Commands.CreateJobType;
using JobStack.Application.Handlers.JobTypes.Commands.UpdateJobType;

namespace JobStack.Application.Handlers.JobTypes.Validations;

public class UpdateJobTypeCommandValidator:AbstractValidator<UpdateJobTypeCommand>
{
	public UpdateJobTypeCommandValidator()
	{
        RuleFor(c => c.JobTypeId).NotEmpty().WithMessage("JobTypeId is required");
        RuleFor(c => c.TypeName).MaximumLength(120)
            .NotEmpty()
            .WithMessage("Type Name is required");
    }
}
