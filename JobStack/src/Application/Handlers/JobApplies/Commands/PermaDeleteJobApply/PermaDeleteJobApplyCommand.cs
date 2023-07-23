

using JobStack.Application.Common.Constants;
using JobStack.Application.Common.Interfaces;
using JobStack.Application.Common.Results;
using MediatR;

namespace JobStack.Application.Handlers.JobApplies.Commands.PermaDeleteJobApply;

public record PermaDeleteJobApplyCommand(int id) :IRequest<IResult>
{
    public class PermaDeleteJobApplyCommandHandler : IRequestHandler<PermaDeleteJobApplyCommand, IResult>
    {
        private readonly IApplicationDbContext _context;

        public PermaDeleteJobApplyCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IResult> Handle(PermaDeleteJobApplyCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.JobApplies.FindAsync(new object[] { request.id }, cancellationToken);
            if (entity is null)
            {
                return new ErrorResult(Messages.NullMessage);

            }

            _context.JobApplies.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return new Result(true, Messages.DeletedMessage);
        }
    }
}
