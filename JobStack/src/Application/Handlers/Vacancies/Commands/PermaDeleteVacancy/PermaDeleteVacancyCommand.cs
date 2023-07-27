using AutoMapper;
using JobStack.Application.Common.Constants;
using JobStack.Application.Common.Interfaces;
using JobStack.Application.Common.Results;
using MediatR;

namespace JobStack.Application.Handlers.Vacancies.Commands.PermaDeleteVacancy;

public record PermaDeleteVacancyCommand(int id) : IRequest<IResult>
{
    public class PermaDeleteVacancyCommandHandler : IRequestHandler<PermaDeleteVacancyCommand, IResult>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public PermaDeleteVacancyCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IResult> Handle(PermaDeleteVacancyCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Vacancies.FindAsync(request.id);
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
