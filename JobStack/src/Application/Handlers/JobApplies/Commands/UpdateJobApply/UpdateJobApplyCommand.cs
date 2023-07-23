
using JobStack.Application.Common.Constants;
using JobStack.Application.Common.Extensions;
using JobStack.Application.Common.Interfaces;
using JobStack.Application.Common.Results;
using JobStack.Application.Handlers.Categories.Commands.UpdateCategory;
using JobStack.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobStack.Application.Handlers.JobApplies.Commands.UpdateJobApply;

public class UpdateJobApplyCommand:IRequest<IDataResult<UpdateJobApplyCommand>>
{
    public int JobApplyId { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string EmailAddress { get; set; } = null!;
    public string? Description { get; set; }
    public string CvFile { get; set; } = null!;
    [NotMapped]
    public IFormFile CvFileUrl { get; set; } = null!;

    public class UpdateJobApplyCommandHandler : IRequestHandler<UpdateJobApplyCommand, IDataResult<UpdateJobApplyCommand>>
    {
        private readonly IApplicationDbContext _context;

        public UpdateJobApplyCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IDataResult<UpdateJobApplyCommand>> Handle(UpdateJobApplyCommand request, CancellationToken cancellationToken)
        {
            JobApply existJobApply = await _context.JobApplies.FindAsync(request.JobApplyId);

            if (existJobApply is null)
            {
                return new ErrorDataResult<UpdateJobApplyCommand>(Messages.NullMessage);
            }
            if (request.CvFileUrl != null)
            {
                IFormFile file = request.CvFileUrl;

                string newFileName = Guid.NewGuid().ToString();
                newFileName += file.CutFileName(60);
                if (System.IO.File.Exists(Path.Combine(@"D:\Project\JobStackProject\JobStack\src\ApiUI\PhotoFiles\JobApply\")))
                {
                    System.IO.File.Delete(Path.Combine(@"D:\Project\JobStackProject\JobStack\src\ApiUI\PhotoFiles\JobApply\"));
                }
                file.UpdateSaveFile(Path.Combine(newFileName));
                existJobApply.CvFile = newFileName;
            }
            existJobApply.FirstName= request.FirstName;
            existJobApply.LastName= request.LastName;
            existJobApply.EmailAddress= request.EmailAddress;
            existJobApply.Description= request.Description;


            _context.JobApplies.Update(existJobApply);
            await _context.SaveChangesAsync(cancellationToken);



            return new SuccessDataResult<UpdateJobApplyCommand>(request, Messages.Updated);
        }
    }
}
