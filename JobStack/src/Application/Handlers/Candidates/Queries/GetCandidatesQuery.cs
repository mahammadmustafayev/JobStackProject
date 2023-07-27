using AutoMapper;
using JobStack.Application.Common.Interfaces;
using JobStack.Application.Common.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace JobStack.Application.Handlers.Candidates.Queries;

//public record GetCandidatesQuery(int? CountryId,
//        int? CityId) : IRequest<IDataResult<IEnumerable<CandidateDto>>>
public class GetCandidatesQuery : IRequest<IDataResult<IEnumerable<CandidateDto>>>
{
    public class GetCandidatesQueryHandler : IRequestHandler<GetCandidatesQuery, IDataResult<IEnumerable<CandidateDto>>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetCandidatesQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IDataResult<IEnumerable<CandidateDto>>> Handle(GetCandidatesQuery request, CancellationToken cancellationToken)
        {

            return new SuccessDataResult<IEnumerable<CandidateDto>>(
                _mapper.Map<IEnumerable<CandidateDto>>(
                    await _context.Candidates

                    .Include(p => p.Country)
                    //.ThenInclude(x => x.Name)

                    .AsNoTracking()
                    .Include(p => p.City)
                    //.ThenInclude(x => x.CityName)
                    .AsNoTracking()


                    .Where(p => p.IsDeleted == false)


                    .ToListAsync()
                    )
                );
        }
    }
}
