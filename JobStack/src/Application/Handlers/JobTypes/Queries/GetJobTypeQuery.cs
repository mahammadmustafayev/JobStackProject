namespace JobStack.Application.Handlers.JobTypes.Queries;

public record GetJobTypeQuery(int id) : IRequest<IDataResult<IEnumerable<JobTypeDto>>>
{
    public class GetJobTypeQueryHandler : IRequestHandler<GetJobTypeQuery, IDataResult<IEnumerable<JobTypeDto>>>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;

        public GetJobTypeQueryHandler(IMapper mapper, IApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<IDataResult<IEnumerable<JobTypeDto>>> Handle(GetJobTypeQuery request, CancellationToken cancellationToken)
        {
            return new SuccessDataResult<IEnumerable<JobTypeDto>>(
                _mapper.Map<IEnumerable<JobTypeDto>>(
                   await _context.JobTypes
                   .Include(j => j.Vacancies)
                   .AsNoTracking()
                   .Where(j => j.Id == request.id)
                   .ToListAsync()));
        }
    }
}
