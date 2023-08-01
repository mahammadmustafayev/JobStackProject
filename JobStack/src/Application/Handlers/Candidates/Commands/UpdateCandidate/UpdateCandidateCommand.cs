




namespace JobStack.Application.Handlers.Candidates.Commands.UpdateCandidate;

public class UpdateCandidateCommand : IRequest<IDataResult<UpdateCandidateCommand>>
{
    public int CandidateId { get; set; }
    // public string CandidateFirstName { get; set; }
    //public string CandidateLastName { get; set; }
    // public string CandidateEmail { get; set; }
    public string CandidateProfession { get; set; }
    public string Description { get; set; }
    public string CandidateSkillName { get; set; }
    public IFormFile CandidateCVUrl { get; set; }
    public IFormFile CandidateProfileUrl { get; set; }
    public int CountryId { get; set; }
    public int CityId { get; set; }

    public class UpdateCandidateCommandHandler : IRequestHandler<UpdateCandidateCommand, IDataResult<UpdateCandidateCommand>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IHostEnvironment _env;

        public UpdateCandidateCommandHandler(IApplicationDbContext context, IHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public async Task<IDataResult<UpdateCandidateCommand>> Handle(UpdateCandidateCommand request, CancellationToken cancellationToken)
        {
            Candidate existcandidate = await _context.Candidates.FindAsync(request.CandidateId);

            if (existcandidate is null)
            {
                return new ErrorDataResult<UpdateCandidateCommand>(Messages.NullMessage);
            }
            if (request.CandidateProfileUrl != null)
            {
                IFormFile file = request.CandidateProfileUrl;

                string newFileName = Guid.NewGuid().ToString();
                newFileName += file.CutFileName(60);
                if (System.IO.File.Exists(Path.Combine(_env.ContentRootPath, "wwwroot", "Candidate", "Images")))
                {
                    System.IO.File.Delete(Path.Combine(_env.ContentRootPath, "wwwroot", "Candidate", "Images"));
                }
                file.UpdateSaveFile(Path.Combine(newFileName));
                existcandidate.CandidateProfilImage = newFileName;
            }
            if (request.CandidateCVUrl != null)
            {
                IFormFile file = request.CandidateCVUrl;

                string newFileName = Guid.NewGuid().ToString();
                newFileName += file.CutFileName(60);
                if (System.IO.File.Exists(Path.Combine(_env.ContentRootPath, "wwwroot", "Candidate", "Images")))
                {
                    System.IO.File.Delete(Path.Combine(_env.ContentRootPath, "wwwroot", "Candidate", "Resume"));
                }
                file.UpdateSaveFile(Path.Combine(newFileName));
                existcandidate.CandidateCV = newFileName;
            }
            existcandidate.CandidateProfession = request.CandidateProfession;
            existcandidate.Description = request.Description;
            existcandidate.CandidateSkillName = request.CandidateSkillName;
            existcandidate.CityId = request.CityId;
            existcandidate.CountryId = request.CountryId;

            _context.Candidates.Update(existcandidate);

            await _context.SaveChangesAsync(cancellationToken);

            return new SuccessDataResult<UpdateCandidateCommand>(request, Messages.Updated);

        }
    }
}
