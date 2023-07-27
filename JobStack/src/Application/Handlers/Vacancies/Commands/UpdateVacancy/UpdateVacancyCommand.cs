

using JobStack.Application.Common.Constants;
using JobStack.Application.Common.Interfaces;
using JobStack.Application.Common.Results;
using JobStack.Domain.Entities;
using MediatR;

namespace JobStack.Application.Handlers.Vacancies.Commands.UpdateVacancy;

public class UpdateVacancyCommand : IRequest<IDataResult<UpdateVacancyCommand>>
{
    public int VacancyId { get; set; }
    public string TitleName { get; set; } = null!;
    public string? Description { get; set; }
    public string? Salary { get; set; }


    public string? Address { get; set; }

    public string? Experience { get; set; }
    public string? ResponsibilityName { get; set; }
    public string? SkillName { get; set; }

    public int? CountryId { get; set; }

    public int? CityId { get; set; }

    public int CategoryId { get; set; }
    public int JobTypeId { get; set; }


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
            existvacancy.SkillName = request.SkillName;
            existvacancy.TitleName = request.TitleName;
            existvacancy.Description = request.Description;
            existvacancy.Address = request.Address;
            existvacancy.Experience = request.Experience;
            existvacancy.ResponsibilityName = request.ResponsibilityName;
            existvacancy.JobTypeId = request.JobTypeId;
            existvacancy.CategoryId = request.CategoryId;
            existvacancy.CityId = request.CityId;
            existvacancy.CountryId = request.CategoryId;

            _context.Vacancies.Update(existvacancy);
            await _context.SaveChangesAsync(cancellationToken);

            return new SuccessDataResult<UpdateVacancyCommand>(request, Messages.Updated);
        }
    }
}
