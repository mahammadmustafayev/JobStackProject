namespace JobStack.Application.Handlers.Categories.Commands.CreateCategory;

public record ManageCreateCategoryCommand(string CategoryName, IFormFile Photo)
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



            if (request != null)
            {
                if (request.Photo.CheckSize(200))
                {
                    return new ErrorDataResult<ManageCreateCategoryCommand>(Messages.InvalidPhoto);
                }
                if (!request.Photo.CheckType("image/"))
                {
                    return new ErrorDataResult<ManageCreateCategoryCommand>(Messages.InvalidImagePhoto);
                }


                string root = Path.Combine(Directory.GetParent("src").Parent.ToString(), "WebUI", "wwwroot", "data", "category");

                category.Logo = request.Photo.SaveFile(root);




            }
            category.CategoryName = request.CategoryName;

            await _context.Categories.AddAsync(category);

            await _context.SaveChangesAsync(cancellationToken);
            return new SuccessDataResult<ManageCreateCategoryCommand>(request, Messages.Added);
        }
    }
}


//{
//    public string CategoryName { get; set; } = null!;
//    public string Logo { get; set; }
//    [NotMapped]
//    public IFormFile Photo { get; set; }
//}

//public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, int>
//{
//    private readonly IApplicationDbContext _context;


//    public CreateCategoryCommandHandler(IApplicationDbContext context)
//    {
//        _context = context;
//    }

//    public async  Task<int> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
//    {
//        Category entity = new();
//        if (entity != null)
//        {
//            if (entity.Photo.CheckSize(200))
//            {
//                throw new FileException();
//            }
//        }


//        return entity.Id;
//    }
//}

