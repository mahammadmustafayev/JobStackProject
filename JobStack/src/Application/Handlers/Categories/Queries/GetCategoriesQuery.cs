

using AutoMapper;
using JobStack.Application.Common.Interfaces;
using JobStack.Application.Common.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace JobStack.Application.Handlers.Categories.Queries;

public class GetCategoriesQuery : IRequest<IDataResult<IEnumerable<CategoryDto>>>
{
    public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQuery, IDataResult<IEnumerable<CategoryDto>>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetCategoriesQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IDataResult<IEnumerable<CategoryDto>>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
        {
            return new SuccessDataResult<List<CategoryDto>>(
                 _mapper.Map<List<CategoryDto>>(
                     await _context.Categories
                     .Include(c => c.Vacancies)
                     .AsNoTracking()
                     .Where(c => c.IsDeleted == false)
                     .ToListAsync()));

        }


    }

}

