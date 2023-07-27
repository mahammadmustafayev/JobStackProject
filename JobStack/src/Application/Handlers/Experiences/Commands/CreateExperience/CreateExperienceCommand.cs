using AutoMapper;
using JobStack.Application.Common.Constants;
using JobStack.Application.Common.Interfaces;
using JobStack.Application.Common.Results;
using JobStack.Domain.Entities;
using MediatR;

namespace JobStack.Application.Handlers.Experiences.Commands.CreateExperience;

public record CreateExperienceCommand
    (int CandidateId,
    string ExperienceName,
    string ExperienceDescription,
    DateTime ExperienceStartYear,
    DateTime ExperienceEndYear) : IRequest<IDataResult<CreateExperienceCommand>>
{
    public class CreateExperienceCommandHandler : IRequestHandler<CreateExperienceCommand, IDataResult<CreateExperienceCommand>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CreateExperienceCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IDataResult<CreateExperienceCommand>> Handle(CreateExperienceCommand request, CancellationToken cancellationToken)
        {
            //2014-12-01 00:00:00.0000000
            Experience experience = _mapper.Map<Experience>(request);
            experience.CandidateId = request.CandidateId;
            experience.ExperienceName = request.ExperienceName;
            experience.ExperienceDescription = request.ExperienceDescription;
            experience.ExperienceEndYear = request.ExperienceEndYear;
            experience.ExperienceStartYear = request.ExperienceStartYear;


            await _context.Experiences.AddAsync(experience);
            await _context.SaveChangesAsync(cancellationToken);

            return new SuccessDataResult<CreateExperienceCommand>(request, Messages.Added);
        }
    }
}
