namespace JobStack.Application.Handlers.Companies.Queries;

public class GetCompaniesQuery : IRequest<IDataResult<IEnumerable<CompanyDto>>>
{
    public class GetCompaniesQueryHandler : IRequestHandler<GetCompaniesQuery, IDataResult<IEnumerable<CompanyDto>>>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;

        public GetCompaniesQueryHandler(IMapper mapper, IApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<IDataResult<IEnumerable<CompanyDto>>> Handle(GetCompaniesQuery request, CancellationToken cancellationToken)
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
                          .Where(p => p.IsDeleted == false)
                          .ToListAsync()
                    )
                );
        }

        //public async Task<IDataResult<IEnumerable<CompanyDto>>> Handle(GetCompaniesQuery request, CancellationToken cancellationToken)
        //{
        //    return new SuccessDataResult<IEnumerable<CompanyDto>>(
        //          _mapper.Map<IEnumerable<CompanyDto>>(
        //              await _context.Companies
        //                  .Include(p => p.City)
        //                  .AsNoTracking()
        //                  .Include(p => p.Country)
        //                  .AsNoTracking()

        //                  .Where(p => p.IsDeleted == false)
        //                  .ToListAsync()
        //              )
        //        );
        //}
    }
}