namespace JobStack.Application.Handlers.Companies.Commands;

public class UpdateCompanyCommand : IRequest<IDataResult<UpdateCompanyCommand>>
{
    public int CompanyId { get; set; }

    public string? CompanyName { get; set; }
    public string? Description { get; set; }
    public string? CompanyEmail { get; set; }


    public DateTime Founded { get; set; }
    public int NumberOfEmployees { get; set; }

    public int CountryId { get; set; }

    public int CityId { get; set; }

    public string CompanySite { get; set; }
    public string? CompanyLogo { get; set; }

    //public IFormFile CompanyUrl { get; set; }

    public class UpdateCompanyCommandHandler : IRequestHandler<UpdateCompanyCommand, IDataResult<UpdateCompanyCommand>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IHostEnvironment _env;
        private readonly IHttpContextAccessor _accessor;
        private readonly UserManager<ApplicationUser> _userManager;

        public UpdateCompanyCommandHandler(IApplicationDbContext context, IHostEnvironment env, IHttpContextAccessor accessor, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _env = env;
            _accessor = accessor;
            _userManager = userManager;
        }

        public async Task<IDataResult<UpdateCompanyCommand>> Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
        {
            //string root = Path.Combine(Directory.GetParent("src").Parent.ToString(), "WebUI", "wwwroot", "data", "company");
            Company existcompany = await _context.Companies.FindAsync(request.CompanyId);

            //var userex = await _userManager.FindByNameAsync(_accessor.HttpContext.User.Identity.Name);
            //userex.CompanySignUpName = request.CompanyName;
            //userex.UserName = request.CompanyEmail;
            //userex.Email = request.CompanyEmail;
            //userex.NormalizedUserName = request.CompanyEmail.ToUpper();
            //userex.NormalizedEmail = request.CompanyEmail.ToUpper();

            if (existcompany is null)
            {
                return new ErrorDataResult<UpdateCompanyCommand>(Messages.NullMessage);
            }


            existcompany.CompanyName = request.CompanyName;
            existcompany.CompanyEmail = request.CompanyEmail;
            existcompany.CompanyLogo = request.CompanyLogo;
            existcompany.Description = request.Description;
            existcompany.CityId = request.CityId;
            existcompany.CountryId = request.CountryId;
            existcompany.Founded = request.Founded;
            existcompany.NumberOfEmployees = request.NumberOfEmployees;
            existcompany.CompanySite = request.CompanySite;

            //IdentityResult identityResult = await _userManager.UpdateAsync(userex);

            _context.Companies.Update(existcompany);
            await _context.SaveChangesAsync(cancellationToken);

            //if (!identityResult.Succeeded)
            //{
            //    return new ErrorDataResult<UpdateCompanyCommand>(message: JsonConvert.SerializeObject(identityResult.Errors.Select(x => x.Description)));
            //}

            return new SuccessDataResult<UpdateCompanyCommand>(request, Messages.Updated);

        }
    }
}
