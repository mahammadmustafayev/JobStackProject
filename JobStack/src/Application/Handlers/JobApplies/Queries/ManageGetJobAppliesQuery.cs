namespace JobStack.Application.Handlers.JobApplies.Queries;

public class ManageGetJobAppliesQuery : IRequest<IDataResult<IEnumerable<JobApplyDto>>>
{
    public class ManageGetJobAppliesQueryHandler : IRequestHandler<ManageGetJobAppliesQuery, IDataResult<IEnumerable<JobApplyDto>>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ManageGetJobAppliesQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IDataResult<IEnumerable<JobApplyDto>>> Handle(ManageGetJobAppliesQuery request, CancellationToken cancellationToken)
        {
            return new SuccessDataResult<IEnumerable<JobApplyDto>>(
                 _mapper.Map<IEnumerable<JobApplyDto>>(
                     await _context.JobApplies

                     .Include(j => j.Vacancy)
                     .ThenInclude(j => j.Company)
                     .AsNoTracking()
                     .ToListAsync()
                     ));
        }
    }
}
