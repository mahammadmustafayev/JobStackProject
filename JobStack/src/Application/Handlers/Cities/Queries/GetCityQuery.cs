namespace JobStack.Application.Handlers.Cities.Queries;

public record GetCityQuery(int id) : IRequest<IDataResult<IEnumerable<CityDto>>>
{
    public class GetCityQueryHandler : IRequestHandler<GetCityQuery, IDataResult<IEnumerable<CityDto>>>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;

        public GetCityQueryHandler(IMapper mapper, IApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<IDataResult<IEnumerable<CityDto>>> Handle(GetCityQuery request, CancellationToken cancellationToken)
        {
            return new SuccessDataResult<IEnumerable<CityDto>>(
               _mapper.Map<IEnumerable<CityDto>>(
                    await _context.Cities

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
