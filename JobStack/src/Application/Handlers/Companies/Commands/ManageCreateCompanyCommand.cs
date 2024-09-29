namespace JobStack.Application.Handlers.Companies.Commands;

public record ManageCreateCompanyCommand
    (
       string CompanyName,
        string Description,
        DateTime Founded,
        int NumberOfEmployees,
        int CountryId,
        int CityId,
        string CompanyEmail,
        string CompanySite,
        IFormFile CompanyLogoUrl
    ) : IRequest<IDataResult<ManageCreateCompanyCommand>>
{
    public class ManageCreateCompanyCommandHandler : IRequestHandler<ManageCreateCompanyCommand, IDataResult<ManageCreateCompanyCommand>>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;
        private readonly IHostEnvironment _env;

        public ManageCreateCompanyCommandHandler(IMapper mapper, IApplicationDbContext context, IHostEnvironment env)
        {
            _mapper = mapper;
            _context = context;
            _env = env;
        }

        public async Task<IDataResult<ManageCreateCompanyCommand>> Handle(ManageCreateCompanyCommand request, CancellationToken cancellationToken)
        {
            Company company = _mapper.Map<Company>(request);
            string root = Path.Combine(Directory.GetParent("src").Parent.ToString(), "ApiUI", "wwwroot", "data", "company");

            if (request != null)
            {
                if (request.CompanyLogoUrl.CheckSize(200))
                {
                    return new ErrorDataResult<ManageCreateCompanyCommand>(Messages.InvalidPhoto);
                }
                if (!request.CompanyLogoUrl.CheckType("image/"))
                {
                    return new ErrorDataResult<ManageCreateCompanyCommand>(Messages.InvalidImagePhoto);
                }
                company.CompanyLogo = request.CompanyLogoUrl.SaveFile(root);
            }
            company.CompanyName = request.CompanyName;
            company.Description = request.Description;
            company.CityId = request.CityId;
            company.CountryId = request.CountryId;
            company.CompanyEmail = request.CompanyEmail;
            company.NumberOfEmployees = request.NumberOfEmployees;
            company.Founded = request.Founded;
            company.CompanySite = request.CompanySite;

            await _context.Companies.AddAsync(company);
            await _context.SaveChangesAsync(cancellationToken);
            return new SuccessDataResult<ManageCreateCompanyCommand>(Messages.Added);
        }
    }

}
