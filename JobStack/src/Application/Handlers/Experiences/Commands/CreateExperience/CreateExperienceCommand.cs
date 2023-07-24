using JobStack.Application.Common.Constants;
using JobStack.Application.Common.Interfaces;
using JobStack.Application.Common.Results;
using JobStack.Domain.Entities;
using MediatR;

namespace JobStack.Application.Handlers.Experiences.Commands.CreateExperience;

public record CreateExperienceCommand
    (string ExperienceName,
    string ExperienceDescription,
    DateTime ExperienceStartYear,
    DateTime ExperienceEndYear) : IRequest<IDataResult<CreateExperienceCommand>>
{
    public class CreateExperienceCommandHandler : IRequestHandler<CreateExperienceCommand, IDataResult<CreateExperienceCommand>>
    {
        private readonly IApplicationDbContext _context;

        public CreateExperienceCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IDataResult<CreateExperienceCommand>> Handle(CreateExperienceCommand request, CancellationToken cancellationToken)
        {
            Experience experience = new()
            {
                ExperienceName = request.ExperienceName,
                ExperienceDescription = request.ExperienceDescription,
                ExperienceEndYear = request.ExperienceEndYear,
                ExperienceStartYear = request.ExperienceStartYear,

            };
            //await _context.Experiences.AddAsync(experience);
            await _context.SaveChangesAsync(cancellationToken);

            return new SuccessDataResult<CreateExperienceCommand>(request, Messages.Added);
        }
    }
}
