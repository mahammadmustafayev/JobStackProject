using AutoMapper;
using JobStack.Application.Common.Constants;
using JobStack.Application.Common.Interfaces;
using JobStack.Application.Common.Results;
using JobStack.Domain.Entities;
using MediatR;

namespace JobStack.Application.Handlers.JobTypes.Commands.CreateJobType;

public record CreateJobTypeCommand(string TypeName) : IRequest<IDataResult<CreateJobTypeCommand>>
{
    public class CreateJobTypeCommandHandler : IRequestHandler<CreateJobTypeCommand, IDataResult<CreateJobTypeCommand>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CreateJobTypeCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IDataResult<CreateJobTypeCommand>> Handle(CreateJobTypeCommand request, CancellationToken cancellationToken)
        {
            JobType jobType = _mapper.Map<JobType>(request);
            jobType.TypeName = request.TypeName;
            //JobType jobType = new()
            //{
            //    TypeName = request.TypeName,
            //};
            await _context.JobTypes.AddAsync(jobType);
            await _context.SaveChangesAsync(cancellationToken);

            return new SuccessDataResult<CreateJobTypeCommand>(request, Messages.Added);
        }
    }
}
