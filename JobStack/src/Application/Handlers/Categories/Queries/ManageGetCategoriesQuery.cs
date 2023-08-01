namespace JobStack.Application.Handlers.Categories.Queries;

public class ManageGetCategoriesQuery : IRequest<IDataResult<IEnumerable<CategoryDto>>>
{
    public class ManageGetCategoriesQueryHandler : IRequestHandler<ManageGetCategoriesQuery, IDataResult<IEnumerable<CategoryDto>>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ManageGetCategoriesQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IDataResult<IEnumerable<CategoryDto>>> Handle(ManageGetCategoriesQuery request, CancellationToken cancellationToken)
        {
            return new SuccessDataResult<List<CategoryDto>>(
                 _mapper.Map<List<CategoryDto>>(
                     await _context.Categories
                     .Include(c => c.Vacancies)
                     .AsNoTracking()
                     .ToListAsync()));
        }
    }
}
