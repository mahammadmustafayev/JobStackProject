



namespace JobStack.Application.Handlers.Authorizations.Commands;

public record LoginUserCommand(string Email, string Password, bool RememberMe) : IRequest<IDataResult<LoginUserCommand>>
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, IDataResult<LoginUserCommand>>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public LoginUserCommandHandler(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IDataResult<LoginUserCommand>> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {


            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user is null)
            {
                return new ErrorDataResult<LoginUserCommand>(Messages.UserNotFound);
            }
            var result = await _signInManager.PasswordSignInAsync(user, request.Password, request.RememberMe, false);
            if (!result.Succeeded) return new ErrorDataResult<LoginUserCommand>(Messages.InvalidUser);

            return new SuccessDataResult<LoginUserCommand>(Messages.LoginSucces);

        }
    }
}
