

using FluentValidation;
using JobStack.Application.Handlers.Categories.Commands.UpdateCategory;

namespace JobStack.Application.Handlers.Categories.Validations;

public class UpdateCategoryCommandValidator:AbstractValidator<UpdateCategoryCommand>
{
	public UpdateCategoryCommandValidator()
	{
        RuleFor(c => c.CategoryId).NotEmpty().WithMessage("CategoryId is required");
        RuleFor(c => c.CategoryName).MaximumLength(200).NotEmpty().WithMessage("Category Name is required");
        RuleFor(c => c.Logo).NotEmpty();
        RuleFor(c => c.Photo).NotEmpty();
    }
}
