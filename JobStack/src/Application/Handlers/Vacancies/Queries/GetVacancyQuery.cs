using AutoMapper;
using JobStack.Application.Common.Interfaces;
using JobStack.Application.Common.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace JobStack.Application.Handlers.Vacancies.Queries;

public record GetVacancyQuery(int id) : IRequest<IDataResult<IEnumerable<VacancyDto>>>
{
    public class GetVacancyQueryHandler : IRequestHandler<GetVacancyQuery, IDataResult<IEnumerable<VacancyDto>>>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;

        public GetVacancyQueryHandler(IMapper mapper, IApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<IDataResult<IEnumerable<VacancyDto>>> Handle(GetVacancyQuery request, CancellationToken cancellationToken)
        {
            return new SuccessDataResult<IEnumerable<VacancyDto>>(
                  _mapper.Map<IEnumerable<VacancyDto>>(
                     await _context.Vacancies
                     .Include(v => v.Category)
                     .AsNoTracking()
                     .Include(v => v.City)
                     .AsNoTracking()
                     .Include(v => v.Country)
                     .AsNoTracking()
                     .Include(v => v.Category)
                     .AsNoTracking()
                     .Include(v => v.JobType)
                     .AsNoTracking()

                     .Where(v => v.Id == request.id)
                     .Where(v => v.IsDeleted == false)
                     .ToListAsync()
                      )
                );
        }
    }
}
