namespace JobStack.Application.Handlers.Categories.Commands.DeleteCategory;

public record DeleteCategoryCommand(int id) : IRequest<IResult>
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, IResult>
    {
        private readonly IApplicationDbContext _context;

        public DeleteCategoryCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IResult> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Categories.FindAsync(request.id);
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

