

using JobStack.Application.Common.Exceptions;
using JobStack.Application.Common.Interfaces;
using JobStack.Domain.Entities;
using MediatR;

namespace JobStack.Application.Handlers.Categories.Commands.PermaDeleteCategory;

public record PermaDeleteCategoryCommand(int id):IRequest{}

public class PermaDeleteCategoryCommandHandler : IRequestHandler<PermaDeleteCategoryCommand>
{
    private readonly IApplicationDbContext _context;

    public PermaDeleteCategoryCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(PermaDeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Categories.FindAsync(new object[] { request.id }, cancellationToken);
        if (entity is null)
        {
            throw new NotFoundException(nameof(Category), request.id);
        }

        _context.Categories.Remove(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;   
    }
}
