using JobStack.Application.Common.Constants;
using JobStack.Application.Common.Interfaces;
using JobStack.Application.Common.Results;
using JobStack.Application.Handlers.Countries.Commands.CreateCountry;
using JobStack.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobStack.Application.Handlers.JobTypes.Commands.CreateJobType;

public record CreateJobTypeCommand(string TypeName):IRequest<IDataResult<CreateJobTypeCommand>>
{
    public class CreateJobTypeCommandHandler : IRequestHandler<CreateJobTypeCommand, IDataResult<CreateJobTypeCommand>>
    {
        private readonly IApplicationDbContext _context;

        public CreateJobTypeCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IDataResult<CreateJobTypeCommand>> Handle(CreateJobTypeCommand request, CancellationToken cancellationToken)
        {
            JobType jobType = new()
            {
                TypeName = request.TypeName,
            };
            await _context.JobTypes.AddAsync(jobType);
            await _context.SaveChangesAsync(cancellationToken);

            return new SuccessDataResult<CreateJobTypeCommand>(request, Messages.Added);
        }
    }
}
