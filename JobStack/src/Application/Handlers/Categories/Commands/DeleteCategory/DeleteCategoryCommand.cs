

using JobStack.Application.Common.Constants;
using JobStack.Application.Common.Exceptions;
using JobStack.Application.Common.Interfaces;
using JobStack.Application.Common.Results;
using JobStack.Application.Handlers.Categories.Commands.CreateCategory;
using JobStack.Domain.Entities;
using MediatR;

namespace JobStack.Application.Handlers.Categories.Commands.DeleteCategory;

public record DeleteCategoryCommand(int id):IRequest<IResult>
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand,IResult>
    {
        private readonly IApplicationDbContext _context;

        public DeleteCategoryCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IResult> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Categories.FindAsync(new object[] { request.id }, cancellationToken);
            if (entity is null)
            {
               return  new ErrorResult(Messages.NullMessage);
            }

            entity.IsDeleted = true;

            await _context.SaveChangesAsync(cancellationToken);

            return new Result(true,Messages.DeletedMessage);
        }

        
    }

}

