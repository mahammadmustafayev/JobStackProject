



namespace JobStack.Application.Handlers.Candidates.Commands.PermaDeleteCandidate;

public record PermaDeleteCandidateCommand(int id) : IRequest<IResult>
{
    public class PermaDeleteCandidateCommandHandler : IRequestHandler<PermaDeleteCandidateCommand, IResult>
    {
        private readonly IApplicationDbContext _context;

        public PermaDeleteCandidateCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IResult> Handle(PermaDeleteCandidateCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Candidates.FindAsync(request.id);
            if (entity is null)
            {
                return new ErrorResult(Messages.NullMessage);

            }

            _context.Candidates.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return new Result(true, Messages.DeletedMessage);
        }
    }
}
