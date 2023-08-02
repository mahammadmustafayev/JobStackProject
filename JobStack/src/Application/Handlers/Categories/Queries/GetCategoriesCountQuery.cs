

namespace JobStack.Application.Handlers.Categories.Queries;

public record GetCategoriesCountQuery(int count) : IRequest<IDataResult<IEnumerable<CategoryDto>>>
{
    public class GetCategoriesCountQueryHandler : IRequestHandler<GetCategoriesCountQuery, IDataResult<IEnumerable<CategoryDto>>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetCategoriesCountQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IDataResult<IEnumerable<CategoryDto>>> Handle(GetCategoriesCountQuery request, CancellationToken cancellationToken)
        {
            return new SuccessDataResult<List<CategoryDto>>(
                 _mapper.Map<List<CategoryDto>>(
                     await _context.Categories
                     .Include(c => c.Vacancies)
                     .AsNoTracking()
                     .Where(c => c.IsDeleted == false)
                     .Take(request.count)
                     //.OrderByDescending(c => c.Id)
                     .ToListAsync()));

        }


    }
}
