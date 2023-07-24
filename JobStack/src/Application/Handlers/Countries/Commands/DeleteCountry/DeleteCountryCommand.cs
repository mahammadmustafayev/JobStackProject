using JobStack.Application.Common.Constants;
using JobStack.Application.Common.Interfaces;
using JobStack.Application.Common.Results;
using MediatR;

namespace JobStack.Application.Handlers.Countries.Commands.DeleteCountry;

public record DeleteCountryCommand(int id) : IRequest<IResult>
{
    public class DeleteCountryCommandHandler : IRequestHandler<DeleteCountryCommand, IResult>
    {
        private readonly IApplicationDbContext _context;

        public DeleteCountryCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IResult> Handle(DeleteCountryCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Countries.FindAsync(request.id);
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
