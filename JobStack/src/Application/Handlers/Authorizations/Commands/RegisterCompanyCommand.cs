


namespace JobStack.Application.Handlers.Authorizations.Commands;

public record RegisterCompanyCommand(string CompanyName, string Email, string Password, int CountryId, int CityId, string CompanyLogo) : IRequest<IResult>
{


    public class RegisterCompanyCommandHandler : IRequestHandler<RegisterCompanyCommand, IResult>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;
        private readonly IEmailService _emailService;

        public RegisterCompanyCommandHandler(UserManager<ApplicationUser> userManager, IMapper mapper, IApplicationDbContext context, IEmailService emailService)
        {
            _userManager = userManager;
            _mapper = mapper;
            _context = context;
            _emailService = emailService;
        }

        public async Task<IResult> Handle(RegisterCompanyCommand request, CancellationToken cancellationToken)
        {
            Company company = _mapper.Map<Company>(request);
            //var isAnyUser = await _userManager.FindByEmailAsync(request.Email);
            //if (isAnyUser is not null)
            //{
            //    return new ErrorResult(Messages.EmailExist);
            //}
            ApplicationUser user = new()
            {
                CompanySignUpName = request.CompanyName,
                Email = request.Email,
                UserName = request.Email
            };
            company.CompanyName = request.CompanyName;
            company.CompanyEmail = request.Email;
            company.CityId = request.CityId;
            company.CountryId = request.CountryId;
            company.CompanyLogo = request.CompanyLogo;
            IdentityResult identityResult = await _userManager.CreateAsync(user, request.Password);
            await _context.Companies.AddAsync(company);
            _emailService.SendEmail(request.Email,
               $"""
                <h3 style="font-size: 20px;font-family: system-ui, -apple-system, BlinkMacSystemFont, 'Segoe UI', Roboto, Oxygen, Ubuntu, Cantarell, 'Open Sans', 'Helvetica Neue', sans-serif;">Dəyərli {request.CompanyName}</h3>
                <p style="font-size: 10px;" >Xoş Gəldiniz! Qeydiyyatdan keçdiyiniz üçün təşəkkür edirik.</p>
                <p>Hörmətlə</p>
                <p>JobStack Managment</p>
                <img  src="https://shreethemes.in/jobstack/layouts/assets/images/logo-dark.png" style="width: 200px;height: 45px; ">
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
