namespace JobStack.Application.Handlers.Candidates.Queries;

public record GetCandidateQuery(int id) : IRequest<IDataResult<IEnumerable<CandidateDto>>>
{


    public class GetCandidateQueryHandler : IRequestHandler<GetCandidateQuery, IDataResult<IEnumerable<CandidateDto>>>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;

        public GetCandidateQueryHandler(IMapper mapper, IApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<IDataResult<IEnumerable<CandidateDto>>> Handle(GetCandidateQuery request, CancellationToken cancellationToken)
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
                       .Where(c => c.Id == request.id)
                       .Where(c => c.IsDeleted == false)
                       .ToListAsync()
                    )
                );
        }
    }
}
