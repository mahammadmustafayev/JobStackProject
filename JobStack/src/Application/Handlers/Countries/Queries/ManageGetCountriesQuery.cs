namespace JobStack.Application.Handlers.Countries.Queries;

public class ManageGetCountriesQuery : IRequest<IDataResult<IEnumerable<CountryDto>>>
{
    public class ManageGetCountriesQueryHandler : IRequestHandler<ManageGetCountriesQuery, IDataResult<IEnumerable<CountryDto>>>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;

        public ManageGetCountriesQueryHandler(IMapper mapper, IApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<IDataResult<IEnumerable<CountryDto>>> Handle(ManageGetCountriesQuery request, CancellationToken cancellationToken)
        {
            return new SuccessDataResult<IEnumerable<CountryDto>>(
                 _mapper.Map<IEnumerable<CountryDto>>(
                      await _context.Countries

                      //.Include(c => c.Vacancies)
                      //.AsNoTracking()

                      //.Include(c => c.Companies)
                      //.AsNoTracking()

                      //.Include(c => c.Candidates)
                      //.AsNoTracking()

                      .Where(c => c.IsDeleted == false)
                      .ToListAsync()));
        }
    }
}
