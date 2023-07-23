

using JobStack.Application.Common.Constants;
using JobStack.Application.Common.Interfaces;
using JobStack.Application.Common.Results;
using JobStack.Domain.Entities;
using MediatR;

namespace JobStack.Application.Handlers.Vacancies.Commands.DeleteVacancy;

public record DeleteVacancyCommand(int id) : IRequest<IResult>
{
    public class DeleteVacancyCommandHandler : IRequestHandler<DeleteVacancyCommand, IResult>
    {
        private readonly IApplicationDbContext _context;

        public DeleteVacancyCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IResult> Handle(DeleteVacancyCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Vacancies.FindAsync(new object[] { request.id }, cancellationToken);
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