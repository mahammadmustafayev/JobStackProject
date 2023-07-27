

using AutoMapper;
using JobStack.Application.Common.Constants;
using JobStack.Application.Common.Extensions;
using JobStack.Application.Common.Interfaces;
using JobStack.Application.Common.Results;
using JobStack.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;

namespace JobStack.Application.Handlers.Candidates.Commands;

public record ManageCreateCandidateCommand
    (
        string CandidateFirstName,
        string CandidateLastName,
        string CandidateEmail,
        string CandidateProfession,
        string Description,
        string CandidateSkillName,
        IFormFile CandidateCVUrl,
        IFormFile CandidateProfileUrl,
        int CountryId,
        int CityId
    ) : IRequest<IDataResult<ManageCreateCandidateCommand>>
{
    public class ManageCreateCandidateCommandHandler : IRequestHandler<ManageCreateCandidateCommand, IDataResult<ManageCreateCandidateCommand>>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;
        private readonly IHostEnvironment _env;

        public ManageCreateCandidateCommandHandler(IMapper mapper, IApplicationDbContext context, IHostEnvironment env)
        {
            _mapper = mapper;
            _context = context;
            _env = env;
        }

        public async Task<IDataResult<ManageCreateCandidateCommand>> Handle(ManageCreateCandidateCommand request, CancellationToken cancellationToken)
        {
            Candidate candidate = _mapper.Map<Candidate>(request);
            if (request != null)
            {
                if (request.CandidateProfileUrl.CheckSize(200))
                {
                    return new ErrorDataResult<ManageCreateCandidateCommand>(Messages.InvalidPhoto);
                }
                if (!request.CandidateProfileUrl.CheckType("image/"))
                {
                    return new ErrorDataResult<ManageCreateCandidateCommand>(Messages.InvalidImagePhoto);
                }
                candidate.CandidateProfilImage = request.CandidateProfileUrl.SaveFile(Path.Combine(_env.ContentRootPath, "wwwroot", "Candidate", "Images"));
                candidate.CandidateCV = request.CandidateCVUrl.SaveFile(Path.Combine(_env.ContentRootPath, "wwwroot", "Candidate", "Resume"));
            }
            candidate.CandidateFirstName = request.CandidateFirstName;
            candidate.CandidateLastName = request.CandidateLastName;
            candidate.CandidateEmail = request.CandidateEmail;
            candidate.CandidateProfession = request.CandidateProfession;
            candidate.Description = request.Description;
            candidate.CandidateSkillName = request.CandidateSkillName;
            candidate.CityId = request.CityId;
            candidate.CountryId = request.CountryId;

            await _context.Candidates.AddAsync(candidate);
            await _context.SaveChangesAsync(cancellationToken);

            return new SuccessDataResult<ManageCreateCandidateCommand>(request, Messages.Added);
        }
    }
}
