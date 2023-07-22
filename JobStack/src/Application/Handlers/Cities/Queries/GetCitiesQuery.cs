

using AutoMapper;
using JobStack.Application.Common.Interfaces;
using JobStack.Application.Common.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace JobStack.Application.Handlers.Cities.Queries;

public class GetCitiesQuery:IRequest<IDataResult<CityVM>>
{
   public class GetCitiesQueryHandler : IRequestHandler<GetCitiesQuery, IDataResult<CityVM>>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;

        public GetCitiesQueryHandler(IMapper mapper, IApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<IDataResult<CityVM>> Handle(GetCitiesQuery request, CancellationToken cancellationToken)
        {
            return new SuccessDataResult<CityVM>(
                _mapper.Map<CityVM>(
                     await _context.Cities

                     .Include(c=>c.Vacancies)
                     .AsNoTracking()

                     .Include(c=>c.Companies)
                     .AsNoTracking()

                     .Include(c=>c.Candidates)
                     .AsNoTracking()

                     .Where(c=>c.IsDeleted==false)
                     .ToListAsync()));
        }
    }
}
