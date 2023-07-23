using JobStack.Application.Common.Constants;
using JobStack.Application.Common.Interfaces;
using JobStack.Application.Common.Results;
using JobStack.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobStack.Application.Handlers.Vacancies.Commands.CreateVacancy;

public class CreateVacancyCommand : IRequest<IDataResult<CreateVacancyCommand>>
{
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

    public class CreateVacancyCommandHandler : IRequestHandler<CreateVacancyCommand, IDataResult<CreateVacancyCommand>>
    {
        private readonly IApplicationDbContext _context;

        public CreateVacancyCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IDataResult<CreateVacancyCommand>> Handle(CreateVacancyCommand request, CancellationToken cancellationToken)
        {
            Vacancy vacancy = new()
            {
                TitleName = request.TitleName,
                Address = request.Address,
                City = request.City,
                Country = request.Country,
                Category = request.Category,
                Company = request.Company,
                JobType = request.JobType,
                Description = request.Description,
                Experience = request.Experience,
                Salary = request.Salary,
                SkillsArray = request.SkillsArray,
                ResponsibilitiesArray = request.ResponsibilitiesArray,
                SkillName = request.SkillName,
                ResponsibilityName = request.ResponsibilityName,
            };

            await _context.Vacancies.AddAsync(vacancy);
            await _context.SaveChangesAsync(cancellationToken);
            return new SuccessDataResult<CreateVacancyCommand>(request, Messages.Added);
        }
    }
}

