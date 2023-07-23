

using JobStack.Application.Common.Constants;
using JobStack.Application.Common.Extensions;
using JobStack.Application.Common.Interfaces;
using JobStack.Application.Common.Results;
using JobStack.Application.Handlers.Categories.Commands.CreateCategory;
using JobStack.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace JobStack.Application.Handlers.JobApplies.Commands.CreateJobApply;

public record CreateJobApplyCommand
    (
      string FirstName,
      string LastName,
      string EmailAddress,
      string? Description,
      string CvFile,
      IFormFile CvFileUrl
    ):IRequest<IDataResult<CreateJobApplyCommand>>
{
    public class CreateJobApplyCommandHandler : IRequestHandler<CreateJobApplyCommand, IDataResult<CreateJobApplyCommand>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IEmailService _emailService;

        public CreateJobApplyCommandHandler(IApplicationDbContext context, IEmailService emailService)
        {
            _context = context;
            _emailService = emailService;
        }

        public async Task<IDataResult<CreateJobApplyCommand>> Handle(CreateJobApplyCommand request, CancellationToken cancellationToken)
        {
            JobApply jobApply = new()
            {
                FirstName=request.FirstName,
                LastName=request.LastName,
                Description=request.Description,
                EmailAddress=request.EmailAddress
                
            };
            if (request != null)
            {
                if (request.CvFileUrl.CheckSize(500))
                {
                    return new ErrorDataResult<CreateJobApplyCommand>(Messages.InvalidCvFile);

                }
                jobApply.CvFile = request.CvFileUrl.SaveFile(Path.Combine(@"D:\Project\JobStackProject\JobStack\src\ApiUI\PhotoFiles\JobApply\"));
            }

            _emailService.SendEmail(request.EmailAddress,Messages.SendEmailMessages
                );

            await _context.JobApplies.AddAsync(jobApply);

            await _context.SaveChangesAsync(cancellationToken);
            return new SuccessDataResult<CreateJobApplyCommand>(request, Messages.Added);


        }
    }
}
