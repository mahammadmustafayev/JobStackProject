namespace JobStack.Application.Handlers.Authorizations.Commands;

public record UserLoginCommand(string data) : IRequest<IDataResult<UserLoginCommand>>
{
    public class UserLoginCommandHandler : IRequestHandler<UserLoginCommand, IDataResult<UserLoginCommand>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        public UserLoginCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IDataResult<UserLoginCommand>> Handle(UserLoginCommand request, CancellationToken cancellationToken)
        {
            UserLogin user = _mapper.Map<UserLogin>(request);
            user.UserData = request.data;
            await _context.UserLogins.AddAsync(user);
            await _context.SaveChangesAsync(cancellationToken);
            return new SuccessDataResult<UserLoginCommand>("Good");

        }
    }
}
