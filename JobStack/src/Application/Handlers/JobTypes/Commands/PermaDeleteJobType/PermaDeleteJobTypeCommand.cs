

using JobStack.Application.Common.Constants;
using JobStack.Application.Common.Interfaces;
using JobStack.Application.Common.Results;
using MediatR;

namespace JobStack.Application.Handlers.JobTypes.Commands.PermaDeleteJobType;

public record PermaDeleteJobTypeCommand(int id):IRequest<IResult>
{
    public class PermaDeleteJobTypeCommandHandler : IRequestHandler<PermaDeleteJobTypeCommand, IResult>
    {
        private readonly IApplicationDbContext _context;

        public PermaDeleteJobTypeCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IResult> Handle(PermaDeleteJobTypeCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.JobTypes.FindAsync(new object[] { request.id }, cancellationToken);
            if (entity is null)
            {
                return new ErrorResult(Messages.NullMessage);

            }

            _context.JobTypes.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return new Result(true, Messages.DeletedMessage);
        }
    }
}
