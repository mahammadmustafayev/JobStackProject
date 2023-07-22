using JobStack.Application.Common.Constants;
using JobStack.Application.Common.Interfaces;
using JobStack.Application.Common.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobStack.Application.Handlers.Cities.Commands.DeleteCity;

public record DeleteCityCommand(int id):IRequest<IResult>
{
    

    public class DeleteCityCommandHandler : IRequestHandler<DeleteCityCommand, IResult>
    {
        private readonly IApplicationDbContext _context;

        public DeleteCityCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IResult> Handle(DeleteCityCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Cities.FindAsync(new object[] { request.id }, cancellationToken);
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
