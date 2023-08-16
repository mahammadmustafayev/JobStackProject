namespace JobStack.Application.Handlers.Candidates.Commands.UpdateCandidate;

public class UpdateCandidateCommand : IRequest<IDataResult<UpdateCandidateCommand>>
{
    public int CandidateId { get; set; }
    private ApplicationUser CandidateUserId { get; set; }
    public string CandidateFirstName { get; set; }
    public string CandidateLastName { get; set; }
    public string CandidateEmail { get; set; }
    public string CandidateProfession { get; set; }
    public string Description { get; set; }
    public string[] CandidateSkillsArray { get; set; }
    public IFormFile CandidateCVUrl { get; set; }
    public IFormFile CandidateProfileUrl { get; set; }
    public int CountryId { get; set; }
    public int CityId { get; set; }

    public class UpdateCandidateCommandHandler : IRequestHandler<UpdateCandidateCommand, IDataResult<UpdateCandidateCommand>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IHttpContextAccessor _accessor;
        private readonly IHostEnvironment _env;
        private readonly UserManager<ApplicationUser> _userManager;

        public UpdateCandidateCommandHandler(IApplicationDbContext context, IHostEnvironment env, UserManager<ApplicationUser> userManager, IHttpContextAccessor accessor)
        {
            _context = context;
            _env = env;
            _userManager = userManager;
            _accessor = accessor;
        }

        public async Task<IDataResult<UpdateCandidateCommand>> Handle(UpdateCandidateCommand request, CancellationToken cancellationToken)
        {
            string rootv1 = Path.Combine(Directory.GetParent("src").Parent.ToString(), "WebUI", "wwwroot", "data", "candidate", "images");
            string rootv2 = Path.Combine(Directory.GetParent("src").Parent.ToString(), "WebUI", "wwwroot", "data", "candidate", "resume");
            Candidate existcandidate = await _context.Candidates.FindAsync(request.CandidateId);

            var userex = await _userManager.FindByNameAsync(_accessor.HttpContext.User.Identity.Name);
            //ApplicationUser user = new()
            //{
            //    FirstName = request.CandidateFirstName,
            //    LastName = request.CandidateLastName,
            //    Email = request.CandidateEmail,
            //    UserName = request.CandidateEmail
            //};
            userex.FirstName = request.CandidateFirstName;
            userex.LastName = request.CandidateLastName;
            userex.Email = request.CandidateEmail;
            userex.UserName = request.CandidateEmail;
            userex.NormalizedUserName = request.CandidateEmail.ToUpper();
            userex.NormalizedEmail = request.CandidateEmail.ToUpper();
            //var candidateex = _context.Candidates.FirstOrDefault(x => x.CandidateEmail == user.Email);
            if (existcandidate is null)
            {
                return new ErrorDataResult<UpdateCandidateCommand>(Messages.NullMessage);
            }
            if (request.CandidateProfileUrl != null)
            {
                IFormFile file = request.CandidateProfileUrl;

                string newFileName = Guid.NewGuid().ToString();
                newFileName += file.CutFileName(60);
                if (System.IO.File.Exists(rootv1))
                {
                    System.IO.File.Delete(rootv1);
                }
                file.UpdateSaveFile(Path.Combine(newFileName));
                existcandidate.CandidateProfilImage = newFileName;
            }
            if (request.CandidateCVUrl != null)
            {
                IFormFile file = request.CandidateCVUrl;

                string newFileName = Guid.NewGuid().ToString();
                newFileName += file.CutFileName(60);
                if (System.IO.File.Exists(rootv2))
                {
                    System.IO.File.Delete(rootv2);
                }
                file.UpdateSaveFile(Path.Combine(newFileName));
                existcandidate.CandidateCV = newFileName;
            }
            existcandidate.CandidateFirstName = request.CandidateFirstName;
            existcandidate.CandidateLastName = request.CandidateLastName;
            existcandidate.CandidateEmail = request.CandidateEmail;
            existcandidate.CandidateProfession = request.CandidateProfession;
            existcandidate.Description = request.Description;
            existcandidate.CandidateSkillName = System.Text.Json.JsonSerializer.Serialize<string[]>(request.CandidateSkillsArray); ;
            existcandidate.CityId = request.CityId;
            existcandidate.CountryId = request.CountryId;
            IdentityResult identityResult = await _userManager.UpdateAsync(userex);

            _context.Candidates.Update(existcandidate);

            await _context.SaveChangesAsync(cancellationToken);
            if (!identityResult.Succeeded)
            {
                return new ErrorDataResult<UpdateCandidateCommand>(message: JsonConvert.SerializeObject(identityResult.Errors.Select(x => x.Description)));
            }
            return new SuccessDataResult<UpdateCandidateCommand>(request, Messages.Updated);

        }
    }
}
