namespace JobStack.Application.Handlers.Companies.Queries;

public record GetCompanyQuery(int id) : IRequest<IDataResult<IEnumerable<CompanyDto>>>
{
    public class GetCompanyQueryHandler : IRequestHandler<GetCompanyQuery, IDataResult<IEnumerable<CompanyDto>>>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;

        public GetCompanyQueryHandler(IMapper mapper, IApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<IDataResult<IEnumerable<CompanyDto>>> Handle(GetCompanyQuery request, CancellationToken cancellationToken)
        {
            return new SuccessDataResult<IEnumerable<CompanyDto>>(
                  _mapper.Map<IEnumerable<CompanyDto>>(
                      await _context.Companies
                          .Include(p => p.City)
                          .AsNoTracking()
                          .Include(p => p.Vacancies).ThenInclude(p => p.JobType)
                          .Include(p => p.Vacancies).ThenInclude(p => p.Country)
                          .Include(p => p.Vacancies).ThenInclude(p => p.City)
                          .AsNoTracking()
                          .Include(p => p.Country)
                          .AsNoTracking()
                          .Include(p => p.CompanyUser)
                          .AsNoTracking()
                          .Where(p => p.Id == request.id)
                          .Where(p => p.IsDeleted == false)
                          .ToListAsync()
                      )
                );
        }
    }
}
