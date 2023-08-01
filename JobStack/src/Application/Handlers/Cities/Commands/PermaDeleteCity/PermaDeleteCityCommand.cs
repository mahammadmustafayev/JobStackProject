namespace JobStack.Application.Handlers.Cities.Commands.PermaDeleteCity;

public record PermaDeleteCityCommand(int id) : IRequest<IResult>
{
    public class PermaDeleteCityCommandHandler : IRequestHandler<PermaDeleteCityCommand, IResult>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public PermaDeleteCityCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IResult> Handle(PermaDeleteCityCommand request, CancellationToken cancellationToken)
        {
            //var entity = await _context.Cities.FindAsync(new object[] { request.id }, cancellationToken);
            var entity = await _context.Cities.FindAsync(request.id);
            if (entity is null)
            {
                return new ErrorResult(Messages.NullMessage);

            }

            _context.Cities.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return new Result(true, Messages.DeletedMessage);
        }
    }
}
