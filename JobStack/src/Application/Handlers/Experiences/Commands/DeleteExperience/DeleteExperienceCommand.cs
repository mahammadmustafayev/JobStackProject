
using JobStack.Application.Common.Constants;
using JobStack.Application.Common.Interfaces;
using JobStack.Application.Common.Results;
using MediatR;

namespace JobStack.Application.Handlers.Experiences.Commands.DeleteExperience;

public record DeleteExperienceCommand(int id) : IRequest<IResult>
{
    public class DeleteExperienceCommandHandler : IRequestHandler<DeleteExperienceCommand, IResult>
    {
        private readonly IApplicationDbContext _context;

        public DeleteExperienceCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IResult> Handle(DeleteExperienceCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Experiences.FindAsync(request.id);
            if (entity is null)
            {
                return new ErrorResult(Messages.NullMessage);
            }

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
