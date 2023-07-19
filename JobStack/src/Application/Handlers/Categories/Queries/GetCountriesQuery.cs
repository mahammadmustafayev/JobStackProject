

using AutoMapper;
using AutoMapper.QueryableExtensions;
using JobStack.Application.Common.Interfaces;
using JobStack.Application.Common.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace JobStack.Application.Handlers.Categories.Queries;

public class GetCountriesQuery:IRequest<IDataResult<CategoryVM>>
{
    public class GetCountriesQueryHandler : IRequestHandler<GetCountriesQuery, IDataResult<CategoryVM>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetCountriesQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IDataResult<CategoryVM>> Handle(GetCountriesQuery request, CancellationToken cancellationToken)
        {
            return new SuccessDataResult<CategoryVM>(
                 _mapper.Map<CategoryVM>(
                     await _context.Categories
                     .Include(c=>c.Vacancies)
                     .AsNoTracking()
                     .Where(c=>c.IsDeleted==false)
                     .ToListAsync()));
            
        }

        
    }

}

