namespace JobStack.Application.Handlers.Categories.Queries;

public record GetCategoryQuery(int id) : IRequest<IDataResult<IEnumerable<CategoryDto>>>
{
    public class GetCategoryQueryHandler : IRequestHandler<GetCategoryQuery, IDataResult<IEnumerable<CategoryDto>>>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;

        public GetCategoryQueryHandler(IMapper mapper, IApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<IDataResult<IEnumerable<CategoryDto>>> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
        {
            return new SuccessDataResult<List<CategoryDto>>(
                 _mapper.Map<List<CategoryDto>>(
                     await _context.Categories
                     .Include(c => c.Vacancies)
                     .AsNoTracking()
                     .Where(c => c.IsDeleted == false)
                     .Where(c => c.Id == request.id)
                     .ToListAsync()));
        }
    }
}
