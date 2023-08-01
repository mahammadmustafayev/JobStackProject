namespace JobStack.Application.Handlers.Cities.Commands.DeleteCity;

public record DeleteCityCommand(int id) : IRequest<IResult>
{


    public class DeleteCityCommandHandler : IRequestHandler<DeleteCityCommand, IResult>
    {
        private readonly IApplicationDbContext _context;

        public DeleteCityCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IResult> Handle(DeleteCityCommand request, CancellationToken cancellationToken)
        {
            //var entity = await _context.Cities.FindAsync(new object[] { request.id }, cancellationToken);
            var entity = await _context.Cities.FindAsync(request.id);
            if (entity is null)
            {
                return new ErrorResult(Messages.NullMessage);
            }

            if (entity.IsDeleted == true)
            {
                entity.IsDeleted = false;
            }
            else
            {
                entity.IsDeleted = true;
            }

            await _context.SaveChangesAsync(cancellationToken);

            return new Result(true, Messages.DeletedMessage);
        }
    }
}
