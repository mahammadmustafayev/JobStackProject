

using AutoMapper;
using JobStack.Application.Common.Interfaces;
using JobStack.Application.Common.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace JobStack.Application.Handlers.Vacancies.Queries;

public class GetVacanciesQuery : IRequest<IDataResult<IEnumerable<VacancyDto>>>
{
    public class GetVacanciesQueryHandler : IRequestHandler<GetVacanciesQuery, IDataResult<IEnumerable<VacancyDto>>>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;

        public GetVacanciesQueryHandler(IMapper mapper, IApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<IDataResult<IEnumerable<VacancyDto>>> Handle(GetVacanciesQuery request, CancellationToken cancellationToken)
        {
            return new SuccessDataResult<IEnumerable<VacancyDto>>(
                _mapper.Map<IEnumerable<VacancyDto>>(
                    await _context.Vacancies
                    //.Include(p => p.C)
                    //.AsNoTracking()
                    .Include(p => p.JobType)
                    .AsNoTracking()
                    .Include(p => p.Category)
                    .AsNoTracking()
                    .Include(p => p.City)
                    .AsNoTracking()
                    .Include(p => p.Country)
                    .AsNoTracking()

                    .Include(v => v.JobApplies)
                    .AsNoTracking()
                    .Where(v => v.IsDeleted == false)
                    .ToListAsync()));
        }
    }
}
