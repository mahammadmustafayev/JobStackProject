using JobStack.Application.Common.Constants;
using JobStack.Application.Common.Interfaces;
using JobStack.Application.Common.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobStack.Application.Handlers.Experiences.Commands.PermaDeleteExperience;

public record PermaDeleteExperienceCommand(int id):IRequest<IResult>
{
    public class PermaDeleteExperienceCommandHandler : IRequestHandler<PermaDeleteExperienceCommand, IResult>
    {
        private readonly IApplicationDbContext _context;

        public PermaDeleteExperienceCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IResult> Handle(PermaDeleteExperienceCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Experiences.FindAsync(new object[] { request.id }, cancellationToken);
            if (entity is null)
            {
                return new ErrorResult(Messages.NullMessage);

            }

            _context.Experiences.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return new Result(true, Messages.DeletedMessage);
        }
    }
}
