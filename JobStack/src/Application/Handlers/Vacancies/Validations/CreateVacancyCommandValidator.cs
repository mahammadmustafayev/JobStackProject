
using FluentValidation;
using JobStack.Application.Handlers.Vacancies.Commands.CreateVacancy;

namespace JobStack.Application.Handlers.Vacancies.Validations;

public class CreateVacancyCommandValidator:AbstractValidator<CreateVacancyCommand>
{
	public CreateVacancyCommandValidator()
	{
		RuleFor(v=>v.TitleName).NotEmpty();
		RuleFor(v=>v.Description);
		RuleFor(v => v.Salary);
		RuleFor(v => v.Address);
		RuleFor(v => v.Experience);
		RuleFor(v => v.ResponsibilitiesArray);
		RuleFor(v => v.ResponsibilityName);
		RuleFor(v => v.SkillName);
		RuleFor(v => v.SkillsArray);
		RuleFor(v => v.Country);
		RuleFor(v => v.City);
		RuleFor(v => v.Category);
		RuleFor(v => v.JobType);
		RuleFor(v => v.Company);
	}
}
