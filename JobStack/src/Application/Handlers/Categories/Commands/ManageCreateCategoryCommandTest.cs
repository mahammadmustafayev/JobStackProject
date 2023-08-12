

namespace JobStack.Application.Handlers.Categories.Commands;

public record ManageCreateCategoryCommandTest(string CategoryName, IFormFile Photo) : IRequest<IDataResult<ManageCreateCategoryCommandTest>>
{
    public class ManageCreateCategoryCommandHandler : IRequestHandler<ManageCreateCategoryCommandTest, IDataResult<ManageCreateCategoryCommandTest>>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;

        public ManageCreateCategoryCommandHandler(IMapper mapper, IApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<IDataResult<ManageCreateCategoryCommandTest>> Handle(ManageCreateCategoryCommandTest request, CancellationToken cancellationToken)
        {
            Category category = _mapper.Map<Category>(request);



            if (request != null)
            {
                if (request.Photo.CheckSize(200))
                {
                    return new ErrorDataResult<ManageCreateCategoryCommandTest>(Messages.InvalidPhoto);
                }
                if (!request.Photo.CheckType("image/"))
                {
                    return new ErrorDataResult<ManageCreateCategoryCommandTest>(Messages.InvalidImagePhoto);
                }


                string root = Path.Combine(Directory.GetParent("src").Parent.ToString(), "WebUI", "wwwroot", "data", "categorytest");

                category.Logo = request.Photo.SaveFile(root);




            }
            category.CategoryName = request.CategoryName;

            await _context.Categories.AddAsync(category);

            await _context.SaveChangesAsync(cancellationToken);
            return new SuccessDataResult<ManageCreateCategoryCommandTest>(request, Messages.Added);

        }
    }
}
