

using AutoMapper;
using JobStack.Application.Common.Constants;
using JobStack.Application.Common.Extensions;
using JobStack.Application.Common.Interfaces;
using JobStack.Application.Common.Results;
using JobStack.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;

namespace JobStack.Application.Handlers.JobApplies.Commands;

public record SendJobApplytoCompany
    (
       string FirstName,
      string LastName,
      string EmailAddress,
      string? Description,
      IFormFile CvFileUrl
    ) : IRequest<IDataResult<SendJobApplytoCompany>>
{
    public class SendJobApplytoCompanyHandler : IRequestHandler<SendJobApplytoCompany, IDataResult<SendJobApplytoCompany>>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;
        private readonly IHostEnvironment _env;
        private readonly IEmailService _emailService;

        public SendJobApplytoCompanyHandler(IMapper mapper, IApplicationDbContext context, IHostEnvironment env, IEmailService emailService = null)
        {
            _mapper = mapper;
            _context = context;
            _env = env;
            _emailService = emailService;
        }

        public async Task<IDataResult<SendJobApplytoCompany>> Handle(SendJobApplytoCompany request, CancellationToken cancellationToken)
        {
            JobApply jobApply = _mapper.Map<JobApply>(request);

            if (request != null)
            {
                if (request.CvFileUrl.CheckSize(500))
                {
                    return new ErrorDataResult<SendJobApplytoCompany>(Messages.InvalidCvFile);

                }
                jobApply.CvFile = request.CvFileUrl.SaveFile(Path.Combine(_env.ContentRootPath, "wwwroot", "JobApply"));
            }

            _emailService.SendEmail(request.EmailAddress, Messages.SendEmailMessages
                );

            jobApply.EmailAddress = request.EmailAddress;
            jobApply.FirstName = request.FirstName;
            jobApply.LastName = request.LastName;
            jobApply.Description = request.Description;


            await _context.JobApplies.AddAsync(jobApply);

            await _context.SaveChangesAsync(cancellationToken);
            return new SuccessDataResult<SendJobApplytoCompany>(request, Messages.SendEmailMessages);
        }
    }
}
