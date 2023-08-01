namespace JobStack.Application.Handlers.JobTypes.Commands.DeleteJobType;

public record DeleteJobTypeCommand(int id) : IRequest<IResult>
{
    public class DeleteJobTypeCommandHandler : IRequestHandler<DeleteJobTypeCommand, IResult>
    {
        private readonly IApplicationDbContext _context;

        public DeleteJobTypeCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IResult> Handle(DeleteJobTypeCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.JobTypes.FindAsync(request.id);
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
