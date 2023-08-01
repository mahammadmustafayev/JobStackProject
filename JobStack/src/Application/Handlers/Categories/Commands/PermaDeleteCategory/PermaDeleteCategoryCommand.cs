namespace JobStack.Application.Handlers.Categories.Commands.PermaDeleteCategory;

public record PermaDeleteCategoryCommand(int id) : IRequest<IResult>
{
    public class PermaDeleteCategoryCommandHandler : IRequestHandler<PermaDeleteCategoryCommand, IResult>
    {
        private readonly IApplicationDbContext _context;

        public PermaDeleteCategoryCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IResult> Handle(PermaDeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Categories.FindAsync(request.id);
            if (entity is null)
            {
                return new ErrorResult(Messages.NullMessage);

            }

            _context.Categories.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return new Result(true, Messages.DeletedMessage);
        }
    }

}

