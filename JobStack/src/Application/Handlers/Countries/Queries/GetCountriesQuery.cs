using AutoMapper;
using JobStack.Application.Common.Interfaces;
using JobStack.Application.Common.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace JobStack.Application.Handlers.Countries.Queries;

public class GetCountriesQuery:IRequest<IDataResult<CountryVM>>
{
    public class GetCountriesQueryHandler : IRequestHandler<GetCountriesQuery, IDataResult<CountryVM>>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;

        public GetCountriesQueryHandler(IMapper mapper, IApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<IDataResult<CountryVM>> Handle(GetCountriesQuery request, CancellationToken cancellationToken)
        {
            return new SuccessDataResult<CountryVM>(
                 _mapper.Map<CountryVM>(
                      await _context.Countries

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
