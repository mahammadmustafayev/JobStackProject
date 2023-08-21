namespace JobStack.Application.Handlers.Cities.Queries;

public class ManageGetCitiesQuery : IRequest<IDataResult<IEnumerable<CityDto>>>
{
    public class ManageGetCitiesQueryHandler : IRequestHandler<ManageGetCitiesQuery, IDataResult<IEnumerable<CityDto>>>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;

        public ManageGetCitiesQueryHandler(IMapper mapper, IApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<IDataResult<IEnumerable<CityDto>>> Handle(ManageGetCitiesQuery request, CancellationToken cancellationToken)
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
                     .OrderBy(c => c.CityName)


                     .ToListAsync()));
        }
    }
}
