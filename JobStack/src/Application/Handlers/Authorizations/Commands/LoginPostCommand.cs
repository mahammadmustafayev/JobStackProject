namespace JobStack.Application.Handlers.Authorizations.Commands;

public record LoginPostCommand(string Email, string Password, bool RememberMe) : IRequest<object>
{
    public class LoginPostCommandHandler : IRequestHandler<LoginPostCommand, object>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IHttpContextAccessor _accessor;

        public LoginPostCommandHandler(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IHttpContextAccessor accessor)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _accessor = accessor;
        }
        public async Task<object> Handle(LoginPostCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user is null)
            {
                throw new Exception();
                // return new ErrorDataResult<LoginUserCommand>(Messages.UserNotFound);
            }
            var userex = _accessor.HttpContext.User;
            var result = await _signInManager.PasswordSignInAsync(user, request.Password, request.RememberMe, false);
            if (!result.Succeeded)
            {
                throw new Exception();

            }

            //return new ErrorDataResult<LoginUserCommand>(Messages.InvalidUser);
            //object data = user;
            //return  (IDataResult<object>)data;

            //return new SuccessDataResult<LoginTestCommand>(Messages.LoginSucces);

            return (object)user;
            throw new Exception();
        }
    }
}
