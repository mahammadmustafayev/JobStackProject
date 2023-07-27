using AutoMapper;
using JobStack.Application.Common.Constants;
using JobStack.Application.Common.Interfaces;
using JobStack.Application.Common.Results;
using JobStack.Domain.Entities;
using MediatR;

namespace JobStack.Application.Handlers.Vacancies.Commands.CreateVacancy;

public class CreateVacancyCommand : IRequest<IDataResult<CreateVacancyCommand>>
{
    public int CompanyId { get; set; }
    public string TitleName { get; set; } = null!;
    public string? Description { get; set; }
    public string? Salary { get; set; }


    public string? Address { get; set; }

    public string? Experience { get; set; }
    public string? ResponsibilityName { get; set; }
    public string? SkillName { get; set; }

    public int CountryId { get; set; }

    public int CityId { get; set; }

    public int CategoryId { get; set; }
    public int JobTypeId { get; set; }


    public class CreateVacancyCommandHandler : IRequestHandler<CreateVacancyCommand, IDataResult<CreateVacancyCommand>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CreateVacancyCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IDataResult<CreateVacancyCommand>> Handle(CreateVacancyCommand request, CancellationToken cancellationToken)
        {
            Vacancy vacancy = _mapper.Map<Vacancy>(request);

            vacancy.Salary = request.Salary;
            vacancy.SkillName = request.SkillName;
            vacancy.TitleName = request.TitleName;
            vacancy.ResponsibilityName = request.ResponsibilityName;
            vacancy.Address = request.Address;
            vacancy.CategoryId = request.CategoryId;
            vacancy.CityId = request.CityId;
            vacancy.CompanyId = request.CompanyId;
            vacancy.Description = request.Description;
            vacancy.Experience = request.Experience;

            await _context.Vacancies.AddAsync(vacancy);
            await _context.SaveChangesAsync(cancellationToken);
            return new SuccessDataResult<CreateVacancyCommand>(request, Messages.Added);
        }
    }
}

