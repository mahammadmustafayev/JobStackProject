

using FluentValidation;
using JobStack.Application.Handlers.Categories.Commands.CreateCategory;
using System.Security.Cryptography.X509Certificates;

namespace JobStack.Application.Handlers.Categories.Validations;

public class CreateCategoryCommandValidator:AbstractValidator<CreateCategoryCommand>
{
	public CreateCategoryCommandValidator()
	{
		RuleFor(c=>c.CategoryName).MaximumLength(200)
			.NotEmpty()
			.WithMessage("Category Name is required");

		RuleFor(c => c.Logo).NotEmpty();
		RuleFor(c => c.Photo).NotEmpty();
	}
}
