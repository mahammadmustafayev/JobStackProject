using JobStack.Application.Common.Constants;
using JobStack.Application.Common.Interfaces;
using JobStack.Application.Common.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobStack.Application.Handlers.Countries.Commands.PermaDeleteCountry;

public record PermaDeleteCountryCommand(int id):IRequest<IResult>
{
    public class PermaDeleteCountryCommandHandler : IRequestHandler<PermaDeleteCountryCommand, IResult>
    {
        private readonly IApplicationDbContext _context;

        public PermaDeleteCountryCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IResult> Handle(PermaDeleteCountryCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Countries.FindAsync(new object[] { request.id }, cancellationToken);
            if (entity is null)
            {
                return new ErrorResult(Messages.NullMessage);

            }

            _context.Countries.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return new Result(true, Messages.DeletedMessage);
        }
    }
}
