



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
            string rootv1 = Path.Combine(Directory.GetParent("src").Parent.ToString(), "WebUI", "wwwroot", "data", "candidate", "images");
            string rootv2 = Path.Combine(Directory.GetParent("src").Parent.ToString(), "WebUI", "wwwroot", "data", "candidate", "resume");

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
                candidate.CandidateProfilImage = request.CandidateProfileUrl.SaveFile(rootv1);
                candidate.CandidateCV = request.CandidateCVUrl.SaveFile(rootv2);
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
