

using JobStack.Application.Common.Exceptions;
using JobStack.Application.Common.Interfaces;
using JobStack.Domain.Entities;
using MediatR;

namespace JobStack.Application.Handlers.Categories.Commands.DeleteCategory;

public record DeleteCategoryCommand(int id):IRequest {}

public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteCategoryCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        var entity= await _context.Categories.FindAsync(new object[] { request.id}, cancellationToken);
        if (entity is null)
        {
            throw new NotFoundException(nameof(Category),request.id);
        }

        entity.IsDeleted= true;

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
