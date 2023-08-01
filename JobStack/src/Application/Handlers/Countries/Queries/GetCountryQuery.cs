namespace JobStack.Application.Handlers.Countries.Queries;

public record GetCountryQuery(int id) : IRequest<IDataResult<IEnumerable<CountryDto>>>
{
    public class GetCountryQueryHandler : IRequestHandler<GetCountryQuery, IDataResult<IEnumerable<CountryDto>>>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;

        public GetCountryQueryHandler(IMapper mapper, IApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<IDataResult<IEnumerable<CountryDto>>> Handle(GetCountryQuery request, CancellationToken cancellationToken)
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
                      .Where(c => c.Id == request.id)
                      .ToListAsync()));
        }
    }

}
