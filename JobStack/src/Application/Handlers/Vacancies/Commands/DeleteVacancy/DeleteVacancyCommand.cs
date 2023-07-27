

using JobStack.Application.Common.Constants;
using JobStack.Application.Common.Interfaces;
using JobStack.Application.Common.Results;
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
            var entity = await _context.Vacancies.FindAsync(request.id);
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