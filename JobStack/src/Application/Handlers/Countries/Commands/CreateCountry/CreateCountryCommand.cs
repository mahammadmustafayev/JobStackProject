namespace JobStack.Application.Handlers.Countries.Commands.CreateCountry;

public record CreateCountryCommand(string CountryName) : IRequest<IDataResult<CreateCountryCommand>>
{
    public class CreateCountryCommandHandler : IRequestHandler<CreateCountryCommand, IDataResult<CreateCountryCommand>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CreateCountryCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IDataResult<CreateCountryCommand>> Handle(CreateCountryCommand request, CancellationToken cancellationToken)
        {
            Country country = _mapper.Map<Country>(request);
            //Country country = new()
            //{
            //    Name=request.CountryName,
            //};
            country.Name = request.CountryName;
            await _context.Countries.AddAsync(country);
            await _context.SaveChangesAsync(cancellationToken);

            return new SuccessDataResult<CreateCountryCommand>(request, Messages.Added);
        }
    }
}
