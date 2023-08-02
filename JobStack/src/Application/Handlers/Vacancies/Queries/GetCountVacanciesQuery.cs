namespace JobStack.Application.Handlers.Vacancies.Queries;

public record GetCountVacanciesQuery(int count) : IRequest<IDataResult<IEnumerable<VacancyDto>>>
{
    public class GetCountVacanciesQueryHandler : IRequestHandler<GetCountVacanciesQuery, IDataResult<IEnumerable<VacancyDto>>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetCountVacanciesQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IDataResult<IEnumerable<VacancyDto>>> Handle(GetCountVacanciesQuery request, CancellationToken cancellationToken)
        {
            return new SuccessDataResult<List<VacancyDto>>(
                 _mapper.Map<List<VacancyDto>>(
                     await _context.Vacancies
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
                    .Where(v => v.IsDeleted == false)
                    .Take(request.count)
                    .ToListAsync()));

        }


    }
}
