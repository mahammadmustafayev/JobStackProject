using JobStack.Application.Common.Constants;
using JobStack.Application.Common.Interfaces;
using JobStack.Application.Common.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobStack.Application.Handlers.Vacancies.Commands.PermaDeleteVacancy;

public record PermaDeleteVacancyCommand(int id):IRequest<IResult>
{
    public class PermaDeleteVacancyCommandHandler : IRequestHandler<PermaDeleteVacancyCommand, IResult>
    {
        private readonly IApplicationDbContext _context;

        public PermaDeleteVacancyCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IResult> Handle(PermaDeleteVacancyCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Vacancies.FindAsync(new object[] { request.id }, cancellationToken);
            if (entity is null)
            {
                return new ErrorResult(Messages.NullMessage);

            }

            _context.Vacancies.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return new Result(true, Messages.DeletedMessage);
        }
    }
}
