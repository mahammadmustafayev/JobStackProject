namespace JobStack.Application.Handlers.JobApplies.Queries;

public record GetJobApplyQuery(int id) : IRequest<IDataResult<IEnumerable<JobApplyDto>>>
{


    public class GetJobApplyQueryHandler : IRequestHandler<GetJobApplyQuery, IDataResult<IEnumerable<JobApplyDto>>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetJobApplyQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IDataResult<IEnumerable<JobApplyDto>>> Handle(GetJobApplyQuery request, CancellationToken cancellationToken)
        {
            return new SuccessDataResult<IEnumerable<JobApplyDto>>(
                 _mapper.Map<IEnumerable<JobApplyDto>>(
                     await _context.JobApplies

                     .Include(j => j.Vacancy)
                     .ThenInclude(j => j.Company)
                     .AsNoTracking()
                     .Where(j => j.Id == request.id)
                     .Where(j => j.IsDeleted == false)
                     .ToListAsync()
                     ));
        }
    }
}
