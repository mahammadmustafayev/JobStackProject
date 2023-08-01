namespace JobStack.Application.Handlers.JobTypes.Queries;

public class ManageGetJobTypesQuery : IRequest<IDataResult<IEnumerable<JobTypeDto>>>
{
    public class ManageGetJobTypesQueryHandler : IRequestHandler<ManageGetJobTypesQuery, IDataResult<IEnumerable<JobTypeDto>>>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;

        public ManageGetJobTypesQueryHandler(IMapper mapper, IApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<IDataResult<IEnumerable<JobTypeDto>>> Handle(ManageGetJobTypesQuery request, CancellationToken cancellationToken)
        {
            return new SuccessDataResult<IEnumerable<JobTypeDto>>(
                _mapper.Map<IEnumerable<JobTypeDto>>(
                   await _context.JobTypes
                   .Include(j => j.Vacancies)
                   .AsNoTracking()
                   .ToListAsync()));
        }
    }
}
