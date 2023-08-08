namespace JobStack.Application.Handlers.JobApplies.Queries;

public record GetJobAppliesVacancyQuery(int id) : IRequest<IDataResult<IEnumerable<JobApplyDto>>>
{
    public class GetJobAppliesVacancyQueryHandler : IRequestHandler<GetJobAppliesVacancyQuery, IDataResult<IEnumerable<JobApplyDto>>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetJobAppliesVacancyQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IDataResult<IEnumerable<JobApplyDto>>> Handle(GetJobAppliesVacancyQuery request, CancellationToken cancellationToken)
        {
            return new SuccessDataResult<IEnumerable<JobApplyDto>>(
                 _mapper.Map<IEnumerable<JobApplyDto>>(
                     await _context.JobApplies

                     .Include(j => j.Vacancy)
                     .ThenInclude(j => j.Company)
                     .AsNoTracking()
                     .Where(j => j.VacancyId == request.id)

                     .Where(j => j.IsDeleted == false)

                     .ToListAsync()
                     ));
        }
    }
}
