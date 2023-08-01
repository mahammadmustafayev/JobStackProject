namespace JobStack.Application.Handlers.Companies.Commands;

public record DeleteCompanyCommand(int id) : IRequest<IResult>
{
    public class DeleteCompanyCommandHandler : IRequestHandler<DeleteCompanyCommand, IResult>
    {
        private readonly IApplicationDbContext _context;

        public DeleteCompanyCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IResult> Handle(DeleteCompanyCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Companies.FindAsync(request.id);
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
