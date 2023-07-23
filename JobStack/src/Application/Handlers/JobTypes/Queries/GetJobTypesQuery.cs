

using AutoMapper;
using JobStack.Application.Common.Interfaces;
using JobStack.Application.Common.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace JobStack.Application.Handlers.JobTypes.Queries;

public class GetJobTypesQuery:IRequest<IDataResult<JobTypeVM>>
{
    public class GetJobTypesQueryHandler : IRequestHandler<GetJobTypesQuery, IDataResult<JobTypeVM>>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;

        public GetJobTypesQueryHandler(IMapper mapper, IApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<IDataResult<JobTypeVM>> Handle(GetJobTypesQuery request, CancellationToken cancellationToken)
        {
            return new SuccessDataResult<JobTypeVM>(
                _mapper.Map<JobTypeVM>(
                   await _context.JobTypes
                   .Include(j=>j.Vacancies)
                   .AsNoTracking()
                   .Where(j=>j.IsDeleted==false)
                   .ToListAsync()));
        }
    }
}
