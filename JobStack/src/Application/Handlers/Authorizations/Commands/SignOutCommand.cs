namespace JobStack.Application.Handlers.Authorizations.Commands;

public class SignOutCommand : IRequest<IDataResult<SignOutCommand>>
{
    public class SignOutCommandHandler : IRequestHandler<SignOutCommand, IDataResult<SignOutCommand>>
    {
        private readonly SignInManager<ApplicationUser> _signInManager;

        public SignOutCommandHandler(SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public async Task<IDataResult<SignOutCommand>> Handle(SignOutCommand request, CancellationToken cancellationToken)
        {
            await _signInManager.SignOutAsync();

            return new SuccessDataResult<SignOutCommand>(Messages.SignOut);
        }
    }
}
