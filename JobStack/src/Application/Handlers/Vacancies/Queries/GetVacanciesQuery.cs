

using AutoMapper;
using JobStack.Application.Common.Interfaces;
using JobStack.Application.Common.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace JobStack.Application.Handlers.Vacancies.Queries;

public class GetVacanciesQuery:IRequest<IDataResult<VacancyVM>>
{
    public class GetVacanciesQueryHandler : IRequestHandler<GetVacanciesQuery, IDataResult<VacancyVM>>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;

        public GetVacanciesQueryHandler(IMapper mapper, IApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<IDataResult<VacancyVM>> Handle(GetVacanciesQuery request, CancellationToken cancellationToken)
        {
            return new SuccessDataResult<VacancyVM>(
                _mapper.Map<VacancyVM>(
                    await _context.Vacancies
                    .Include(v => v.JobApplies)
                    .AsNoTracking()
                    .Where(v => v.IsDeleted == false)
                    .ToListAsync()));
        }
    }
}
