namespace JobStack.Application.Handlers.Companies.Queries;

public class ManageGetCompaniesQuery : IRequest<IDataResult<IEnumerable<CompanyDto>>>
{
    public class ManageGetCompaniesQueryHandler : IRequestHandler<ManageGetCompaniesQuery, IDataResult<IEnumerable<CompanyDto>>>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;

        public ManageGetCompaniesQueryHandler(IMapper mapper, IApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<IDataResult<IEnumerable<CompanyDto>>> Handle(ManageGetCompaniesQuery request, CancellationToken cancellationToken)
        {
            return new SuccessDataResult<IEnumerable<CompanyDto>>(
                _mapper.Map<IEnumerable<CompanyDto>>(
                    await _context.Companies
                     .Include(p => p.City)
                          .AsNoTracking()
                          .Include(p => p.Country)
                          .AsNoTracking()
                          .Include(p => p.Vacancies)
                          .AsNoTracking()
                          .ToListAsync()
                    )
                );
        }


    }
}
