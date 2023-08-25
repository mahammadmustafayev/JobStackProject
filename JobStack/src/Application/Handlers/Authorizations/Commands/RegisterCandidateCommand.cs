


namespace JobStack.Application.Handlers.Authorizations.Commands;

public record RegisterCandidateCommand(string FirstName, string LastName, string Email, string Password, int CountryId, int CityId, string CandidateProfilImage) : IRequest<IResult>
{
    public class RegisterCandidateCommandHandler : IRequestHandler<RegisterCandidateCommand, IResult>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;
        private readonly IEmailService _emailService;
        public RegisterCandidateCommandHandler(UserManager<ApplicationUser> userManager, IMapper mapper, IApplicationDbContext context, IEmailService emailService = null)
        {
            _userManager = userManager;
            _mapper = mapper;
            _context = context;
            _emailService = emailService;
        }

        public async Task<IResult> Handle(RegisterCandidateCommand request, CancellationToken cancellationToken)
        {
            Candidate candidate = _mapper.Map<Candidate>(request);
            //var isAnyUser = await _userManager.FindByEmailAsync(request.Email);
            //if (isAnyUser is not null)
            //{
            //    return new ErrorResult(Messages.EmailExist);
            //}
            ApplicationUser user = new()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                UserName = request.Email

            };

            candidate.CandidateFirstName = request.FirstName;
            candidate.CandidateLastName = request.LastName;
            candidate.CandidateEmail = request.Email;
            candidate.CityId = request.CityId;
            candidate.CountryId = request.CountryId;
            candidate.CandidateProfilImage = request.CandidateProfilImage;
            IdentityResult identityResult = await _userManager.CreateAsync(user, request.Password);
            await _context.Candidates.AddAsync(candidate);
            _emailService.SendEmail(request.Email,
               $"""
                <h3 style="font-size: 20px;font-family: system-ui, -apple-system, BlinkMacSystemFont, 'Segoe UI', Roboto, Oxygen, Ubuntu, Cantarell, 'Open Sans', 'Helvetica Neue', sans-serif;">Dəyərli {request.FirstName} {request.LastName}</h3>
                <p style="font-size: 17px;">Xoş Gəldiniz! Qeydiyyatdan keçdiyiniz üçün təşəkkür edirik.</p>
                <p style="font-size: 17px;">Hörmətlə</p>
                <pstyle="color:black;">JobStack Managment</p>
                <img  src="https://shreethemes.in/jobstack/layouts/assets/images/logo-dark.png" style="width: 200px;height: 50px; ">
                """);
            await _context.SaveChangesAsync(cancellationToken);

            if (!identityResult.Succeeded)
            {
                return new ErrorResult(message: JsonConvert.SerializeObject(identityResult.Errors.Select(x => x.Description)));
            }
            return new Result(true, Messages.Registersucces);
        }
    }
}
