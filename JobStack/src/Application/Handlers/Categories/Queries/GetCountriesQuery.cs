

using AutoMapper;
using AutoMapper.QueryableExtensions;
using JobStack.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace JobStack.Application.Handlers.Categories.Queries;

public class GetCountriesQuery:IRequest<CategoryVM>{}

public class GetCountriesQueryHandler : IRequestHandler<GetCountriesQuery, CategoryVM>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetCountriesQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<CategoryVM> Handle(GetCountriesQuery request, CancellationToken cancellationToken)
    {
        return new CategoryVM
        {
            Categories = await _context.Categories
            .Include(x => x.Vacancies).AsNoTracking()
            .Where(x => x.IsDeleted == false)
            .ProjectTo<CategoryDto>(_mapper.ConfigurationProvider)
            .ToListAsync()
        };
    }
}
