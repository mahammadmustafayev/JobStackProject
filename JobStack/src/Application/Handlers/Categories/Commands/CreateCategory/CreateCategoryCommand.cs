namespace JobStack.Application.Handlers.Categories.Commands.CreateCategory;

public record CreateCategoryCommand(string CategoryName, IFormFile Photo)
        : IRequest<IDataResult<CreateCategoryCommand>>
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, IDataResult<CreateCategoryCommand>>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;
        private readonly IHostEnvironment _env;


        public CreateCategoryCommandHandler(IMapper mapper, IApplicationDbContext context, IHostEnvironment env)
        {
            _mapper = mapper;
            _context = context;
            _env = env;
        }

        public async Task<IDataResult<CreateCategoryCommand>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            Category category = _mapper.Map<Category>(request);



            if (request != null)
            {
                if (request.Photo.CheckSize(200))
                {
                    return new ErrorDataResult<CreateCategoryCommand>(Messages.InvalidPhoto);
                }
                if (!request.Photo.CheckType("image/"))
                {
                    return new ErrorDataResult<CreateCategoryCommand>(Messages.InvalidImagePhoto);
                }

                category.Logo = request.Photo.SaveFile(Path.Combine(_env.ContentRootPath, "wwwroot", "Category"));


            }
            category.CategoryName = request.CategoryName;

            await _context.Categories.AddAsync(category);

            await _context.SaveChangesAsync(cancellationToken);
            return new SuccessDataResult<CreateCategoryCommand>(request, Messages.Added);
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

