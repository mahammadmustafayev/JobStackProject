using AutoMapper;
using JobStack.Application.Common.Constants;
using JobStack.Application.Common.Interfaces;
using JobStack.Application.Common.Results;
using MediatR;

namespace JobStack.Application.Handlers.Experiences.Commands.PermaDeleteExperience;

public record PermaDeleteExperienceCommand(int id) : IRequest<IResult>
{
    public class PermaDeleteExperienceCommandHandler : IRequestHandler<PermaDeleteExperienceCommand, IResult>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public PermaDeleteExperienceCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IResult> Handle(PermaDeleteExperienceCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Experiences.FindAsync(request.id);
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
