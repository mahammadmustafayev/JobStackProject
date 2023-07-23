

using JobStack.Application.Common.Constants;
using JobStack.Application.Common.Interfaces;
using JobStack.Application.Common.Results;
using JobStack.Application.Handlers.Countries.Commands.UpdateCountry;
using JobStack.Domain.Entities;
using MediatR;

namespace JobStack.Application.Handlers.JobTypes.Commands.UpdateJobType;

public class UpdateJobTypeCommand:IRequest<IDataResult<UpdateJobTypeCommand>>
{
    public int JobTypeId { get; set; }
    public string TypeName { get; set; }

    public class UpdateJobTypeCommandHandler : IRequestHandler<UpdateJobTypeCommand, IDataResult<UpdateJobTypeCommand>>
    {
        private readonly IApplicationDbContext _context;

        public UpdateJobTypeCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IDataResult<UpdateJobTypeCommand>> Handle(UpdateJobTypeCommand request, CancellationToken cancellationToken)
        {
            JobType existjobtype = await _context.JobTypes.FindAsync(request.JobTypeId);
            if (existjobtype is null)
            {
                return new ErrorDataResult<UpdateJobTypeCommand>(Messages.NullMessage);

            }
            existjobtype.TypeName = request.TypeName;
            _context.JobTypes.Update(existjobtype);
            await _context.SaveChangesAsync(cancellationToken);

            return new SuccessDataResult<UpdateJobTypeCommand>(request, Messages.Updated);
        }
    }
}
