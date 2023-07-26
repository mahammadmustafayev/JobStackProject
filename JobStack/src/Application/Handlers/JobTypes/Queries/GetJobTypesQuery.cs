

using AutoMapper;
using JobStack.Application.Common.Interfaces;
using JobStack.Application.Common.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace JobStack.Application.Handlers.JobTypes.Queries;

public class GetJobTypesQuery : IRequest<IDataResult<IEnumerable<JobTypeDto>>>
{
    public class GetJobTypesQueryHandler : IRequestHandler<GetJobTypesQuery, IDataResult<IEnumerable<JobTypeDto>>>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;

        public GetJobTypesQueryHandler(IMapper mapper, IApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<IDataResult<IEnumerable<JobTypeDto>>> Handle(GetJobTypesQuery request, CancellationToken cancellationToken)
        {
            return new SuccessDataResult<IEnumerable<JobTypeDto>>(
                _mapper.Map<IEnumerable<JobTypeDto>>(
                   await _context.JobTypes
                   .Include(j => j.Vacancies)
                   .AsNoTracking()
                   .Where(j => j.IsDeleted == false)
                   .ToListAsync()));
        }
    }
}
