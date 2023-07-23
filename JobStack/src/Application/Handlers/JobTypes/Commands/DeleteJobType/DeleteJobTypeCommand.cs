

using JobStack.Application.Common.Constants;
using JobStack.Application.Common.Interfaces;
using JobStack.Application.Common.Results;
using MediatR;

namespace JobStack.Application.Handlers.JobTypes.Commands.DeleteJobType;

public record DeleteJobTypeCommand(int id):IRequest<IResult>
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
            var entity = await _context.JobTypes.FindAsync(new object[] { request.id }, cancellationToken);
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
