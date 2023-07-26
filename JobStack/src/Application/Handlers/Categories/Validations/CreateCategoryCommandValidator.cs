

using FluentValidation;
using JobStack.Application.Handlers.Categories.Commands.CreateCategory;

namespace JobStack.Application.Handlers.Categories.Validations;

public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
{
    public CreateCategoryCommandValidator()
    {
        RuleFor(c => c.CategoryName).MaximumLength(200)
            .NotEmpty()
            .WithMessage("Category Name is required");

        //RuleFor(c => c.Logo).Empty();
        //RuleFor(c => c.Photo).Null();
    }
}
