namespace JobStack.Application.Handlers.Cities.Commands.CreateCity;

public record CreateCityCommand(string CityName) : IRequest<IDataResult<CreateCityCommand>>
{
    public class CreateCityCommandHandler : IRequestHandler<CreateCityCommand, IDataResult<CreateCityCommand>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CreateCityCommandHandler(IApplicationDbContext context, IMapper mapper)
        {

            _context = context;
            _mapper = mapper;
        }

        public async Task<IDataResult<CreateCityCommand>> Handle(CreateCityCommand request, CancellationToken cancellationToken)
        {
            City city = _mapper.Map<City>(request);

            //City city = new()
            //{
            //    CityName=request.CityName,
            //};
            city.CityName = request.CityName;
            await _context.Cities.AddAsync(city);
            await _context.SaveChangesAsync(cancellationToken);

            return new SuccessDataResult<CreateCityCommand>(request, Messages.Added);
        }
    }
}
