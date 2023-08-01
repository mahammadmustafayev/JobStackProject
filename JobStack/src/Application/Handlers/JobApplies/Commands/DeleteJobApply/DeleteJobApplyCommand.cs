namespace JobStack.Application.Handlers.JobApplies.Commands.DeleteJobApply;

public record DeleteJobApplyCommand(int id) : IRequest<IResult>
{
    public class DeleteJobApplyCommandHandler : IRequestHandler<DeleteJobApplyCommand, IResult>
    {
        private readonly IApplicationDbContext _context;

        public DeleteJobApplyCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IResult> Handle(DeleteJobApplyCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.JobApplies.FindAsync(new object[] { request.id }, cancellationToken);
            if (entity is null)
            {
                return new ErrorResult(Messages.NullMessage);
            }

            entity.IsDeleted = true;

            await _context.SaveChangesAsync(cancellationToken);

            return new Result(true, Messages.DeletedMessage);
        }
    }
}
