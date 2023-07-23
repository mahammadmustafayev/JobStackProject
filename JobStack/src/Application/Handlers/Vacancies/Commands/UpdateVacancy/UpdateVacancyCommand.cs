

using JobStack.Application.Common.Constants;
using JobStack.Application.Common.Interfaces;
using JobStack.Application.Common.Results;
using JobStack.Application.Handlers.JobTypes.Commands.UpdateJobType;
using JobStack.Domain.Entities;
using MediatR;

namespace JobStack.Application.Handlers.Vacancies.Commands.UpdateVacancy;

public class UpdateVacancyCommand:IRequest<IDataResult<UpdateVacancyCommand>>
{
    public int VacancyId { get; set; }
    public string TitleName { get; set; } = null!;
    public string? Description { get; set; }
    public string? Salary { get; set; }


    public string? Address { get; set; }

    public string? Experience { get; set; }
    public string? ResponsibilityName { get; set; }
    public string[]? ResponsibilitiesArray { get; set; }
    public string? SkillName { get; set; }
    public string[]? SkillsArray { get; set; }

    public int? CountryId { get; set; }
    public Country? Country { get; set; }

    public int? CityId { get; set; }
    public City? City { get; set; }

    public int CategoryId { get; set; }
    public int JobTypeId { get; set; }
    public JobType JobType { get; set; }
    public Category Category { get; set; } = null!;

    public int CompanyId { get; set; }
    public Company Company { get; set; } = null!;

    public class UpdateVacancyCommandHandler : IRequestHandler<UpdateVacancyCommand, IDataResult<UpdateVacancyCommand>>
    {
        private readonly IApplicationDbContext _context;

        public UpdateVacancyCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IDataResult<UpdateVacancyCommand>> Handle(UpdateVacancyCommand request, CancellationToken cancellationToken)
        {
            Vacancy existvacancy = await _context.Vacancies.FindAsync(request.VacancyId);

            if (existvacancy is null)
            {
                return new ErrorDataResult<UpdateVacancyCommand>(Messages.NullMessage);

            }
            existvacancy.Salary = request.Salary;
            existvacancy.City = request.City;
            existvacancy.Country = request.Country;
            existvacancy.SkillName = request.SkillName;
            existvacancy.TitleName = request.TitleName;
            existvacancy.Description = request.Description; 
            existvacancy.SkillsArray = request.SkillsArray;
            existvacancy.Address = request.Address;
            existvacancy.Category = request.Category;
            existvacancy.Company = request.Company;
            existvacancy.Experience = request.Experience;
            existvacancy.JobType = request.JobType;
            existvacancy.ResponsibilitiesArray = request.ResponsibilitiesArray;
            existvacancy.ResponsibilityName= request.ResponsibilityName;
            
            _context.Vacancies.Update(existvacancy);
            await _context.SaveChangesAsync(cancellationToken);

            return new SuccessDataResult<UpdateVacancyCommand>(request, Messages.Updated);
        }
    }
}
