namespace JobStack.Application.Handlers.Vacancies.Queries;

public class ManageGetVacanciesQuery : IRequest<IDataResult<IEnumerable<VacancyDto>>>
{
    public class ManageGetVacanciesQueryHandler : IRequestHandler<ManageGetVacanciesQuery, IDataResult<IEnumerable<VacancyDto>>>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;

        public ManageGetVacanciesQueryHandler(IMapper mapper, IApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<IDataResult<IEnumerable<VacancyDto>>> Handle(ManageGetVacanciesQuery request, CancellationToken cancellationToken)
        {
            return new SuccessDataResult<IEnumerable<VacancyDto>>(
                _mapper.Map<IEnumerable<VacancyDto>>(
                    await _context.Vacancies
                    .Include(p => p.Company)
                    .AsNoTracking()
                    .Include(p => p.JobType)
                    .AsNoTracking()
                    .Include(p => p.Category)
                    .AsNoTracking()
                    .Include(p => p.City)
                    .AsNoTracking()
                    .Include(p => p.Country)
                    .AsNoTracking()

                    .Include(v => v.JobApplies)
                    .AsNoTracking()
                    .OrderByDescending(p => p.Id)

                    .ToListAsync()));
        }
    }
}
