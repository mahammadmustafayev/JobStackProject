﻿namespace JobStack.Application.Handlers.Categories.Commands.UpdateCategory;

public class UpdateCategoryCommand : IRequest<IDataResult<UpdateCategoryCommand>>
{
    public int CategoryId { get; set; }
    public string CategoryName { get; set; }
    //public string Logo { get; set; }
    [NotMapped]
    public IFormFile Photo { get; set; }

    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, IDataResult<UpdateCategoryCommand>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IHostEnvironment _env;

        public UpdateCategoryCommandHandler(IApplicationDbContext context, IHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public async Task<IDataResult<UpdateCategoryCommand>> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            Category existCategory = await _context.Categories.FindAsync(request.CategoryId);

            if (existCategory is null)
            {
                return new ErrorDataResult<UpdateCategoryCommand>(Messages.NullMessage);
            }
            if (request.Photo != null)
            {
                IFormFile file = request.Photo;

                string newFileName = Guid.NewGuid().ToString();
                newFileName += file.CutFileName(60);
                if (System.IO.File.Exists(Path.Combine(_env.ContentRootPath, "wwwroot", "Category")))
                {
                    System.IO.File.Delete(Path.Combine(_env.ContentRootPath, "wwwroot", "Category"));
                }
                file.UpdateSaveFile(Path.Combine(newFileName));
                existCategory.Logo = newFileName;
            }
            existCategory.CategoryName = request.CategoryName;

            _context.Categories.Update(existCategory);
            await _context.SaveChangesAsync(cancellationToken);



            return new SuccessDataResult<UpdateCategoryCommand>(request, Messages.Updated);

        }


    }
}

