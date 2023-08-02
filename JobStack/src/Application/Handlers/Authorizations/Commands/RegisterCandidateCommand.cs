


namespace JobStack.Application.Handlers.Authorizations.Commands;

public record RegisterCandidateCommand(string FirstName, string LastName, string Email, string Password) : IRequest<IResult>
{
    public class RegisterCandidateCommandHandler : IRequestHandler<RegisterCandidateCommand, IResult>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;

        public RegisterCandidateCommandHandler(UserManager<ApplicationUser> userManager, IMapper mapper, IApplicationDbContext context)
        {
            _userManager = userManager;
            _mapper = mapper;
            _context = context;
        }

        public async Task<IResult> Handle(RegisterCandidateCommand request, CancellationToken cancellationToken)
        {
            Candidate candidate = _mapper.Map<Candidate>(request);
            var isAnyUser = await _userManager.FindByEmailAsync(request.Email);
            if (isAnyUser is not null)
            {
                return new ErrorResult(Messages.EmailExist);
            }
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
            IdentityResult identityResult = await _userManager.CreateAsync(user, request.Password);
            await _context.Candidates.AddAsync(candidate);
            await _context.SaveChangesAsync(cancellationToken);

            if (!identityResult.Succeeded)
            {
                return new ErrorResult(message: JsonConvert.SerializeObject(identityResult.Errors.Select(x => x.Description)));
            }
            return new Result(true, Messages.Registersucces);
        }
    }
}
