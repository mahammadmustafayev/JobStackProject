

using AutoMapper;
using JobStack.Application.Common.Interfaces;
using JobStack.Application.Common.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace JobStack.Application.Handlers.JobApplies.Queries;

public record GetJobAppliesQuery : IRequest<IDataResult<IEnumerable<JobApplyDto>>>
{


    public class GetJobAppliesQueryHandler : IRequestHandler<GetJobAppliesQuery, IDataResult<IEnumerable<JobApplyDto>>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetJobAppliesQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IDataResult<IEnumerable<JobApplyDto>>> Handle(GetJobAppliesQuery request, CancellationToken cancellationToken)
        {
            return new SuccessDataResult<IEnumerable<JobApplyDto>>(
                 _mapper.Map<IEnumerable<JobApplyDto>>(
                     await _context.JobApplies

                     .Include(j => j.Vacancy)
                     .ThenInclude(j => j.Company)
                     .AsNoTracking()

                     .Where(j => j.IsDeleted == false)
                     .ToListAsync()
                     ));
        }
    }
}
