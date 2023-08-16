namespace JobStack.Application.Handlers.Categories.Commands.CreateCategory;

public record ManageCreateCategoryCommand(string CategoryName, string Photo)
        : IRequest<IDataResult<ManageCreateCategoryCommand>>
{
    public class CreateCategoryCommandHandler : IRequestHandler<ManageCreateCategoryCommand, IDataResult<ManageCreateCategoryCommand>>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;
        private readonly IHostEnvironment _env;
        //private readonly IWebHostEnvironment _env;

        public CreateCategoryCommandHandler(IMapper mapper, IApplicationDbContext context, IHostEnvironment env)
        {
            _mapper = mapper;
            _context = context;
            _env = env;
        }

        public async Task<IDataResult<ManageCreateCategoryCommand>> Handle(ManageCreateCategoryCommand request, CancellationToken cancellationToken)
        {
            Category category = _mapper.Map<Category>(request);

            category.CategoryName = request.CategoryName;
            category.Logo = request.Photo;
            await _context.Categories.AddAsync(category);

            await _context.SaveChangesAsync(cancellationToken);
            return new SuccessDataResult<ManageCreateCategoryCommand>(request, Messages.Added);
        }
    }
}




