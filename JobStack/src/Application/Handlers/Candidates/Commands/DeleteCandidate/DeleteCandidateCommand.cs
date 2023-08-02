


namespace JobStack.Application.Handlers.Candidates.Commands.DeleteCandidate;

public record DeleteCandidateCommand(int id) : IRequest<IResult>
{
    public class DeleteCandidateCommandHandler : IRequestHandler<DeleteCandidateCommand, IResult>
    {
        private readonly IApplicationDbContext _context;

        public DeleteCandidateCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IResult> Handle(DeleteCandidateCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Candidates.FindAsync(request.id);
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
