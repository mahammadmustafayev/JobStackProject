using JobStack.Application.Common.Constants;
using JobStack.Application.Common.Interfaces;
using JobStack.Application.Common.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobStack.Application.Handlers.Countries.Commands.DeleteCountry;

public record DeleteCountryCommand(int id):IRequest<IResult>
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
            var entity = await _context.Countries.FindAsync(new object[] { request.id }, cancellationToken);
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
