using JobStack.Application.Common.Constants;
using JobStack.Application.Common.Interfaces;
using JobStack.Application.Common.Results;
using JobStack.Domain.Entities;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace JobStack.Application.Handlers.Experiences.Commands.UpdateExperience;

public class UpdateExperienceCommand : IRequest<IDataResult<UpdateExperienceCommand>>
{
    public int ExperienceId { get; set; }
    public string ExperienceName { get; set; }
    public string ExperienceDescription { get; set; }

    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy}")]
    public DateTime ExperienceStartYear { get; set; }

    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy}")]
    public DateTime ExperienceEndYear { get; set; }

    public class UpdateExperienceCommandHandler : IRequestHandler<UpdateExperienceCommand, IDataResult<UpdateExperienceCommand>>
    {
        private readonly IApplicationDbContext _context;

        public UpdateExperienceCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IDataResult<UpdateExperienceCommand>> Handle(UpdateExperienceCommand request, CancellationToken cancellationToken)
        {
            Experience existexperience = await _context.Experiences.FindAsync(request.ExperienceId);
            if (existexperience is null)
            {
                return new ErrorDataResult<UpdateExperienceCommand>(Messages.NullMessage);

            }
            existexperience.ExperienceStartYear = request.ExperienceStartYear;
            existexperience.ExperienceEndYear = request.ExperienceEndYear;
            existexperience.ExperienceDescription = request.ExperienceDescription;
            existexperience.ExperienceName = request.ExperienceName;

            _context.Experiences.Update(existexperience);
            await _context.SaveChangesAsync(cancellationToken);

            return new SuccessDataResult<UpdateExperienceCommand>(request, Messages.Updated);

        }
    }
}
