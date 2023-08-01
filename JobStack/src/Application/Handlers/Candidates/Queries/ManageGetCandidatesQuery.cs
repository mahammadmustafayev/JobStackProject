namespace JobStack.Application.Handlers.Candidates.Queries;

public class ManageGetCandidatesQuery : IRequest<IDataResult<IEnumerable<CandidateDto>>>
{
    public class ManageGetCandidatesQueryHandler : IRequestHandler<ManageGetCandidatesQuery, IDataResult<IEnumerable<CandidateDto>>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ManageGetCandidatesQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IDataResult<IEnumerable<CandidateDto>>> Handle(ManageGetCandidatesQuery request, CancellationToken cancellationToken)
        {
            return new SuccessDataResult<IEnumerable<CandidateDto>>(
                _mapper.Map<IEnumerable<CandidateDto>>(
                    await _context.Candidates

                    .Include(p => p.Country)
                    //.ThenInclude(x => x.Name)

                    .AsNoTracking()
                    .Include(p => p.City)
                    //.ThenInclude(x => x.CityName)
                    .AsNoTracking()

                    .Include(p => p.Experiences)
                    .AsNoTracking()

                    .ToListAsync()
                    )
                );
        }
    }
}
