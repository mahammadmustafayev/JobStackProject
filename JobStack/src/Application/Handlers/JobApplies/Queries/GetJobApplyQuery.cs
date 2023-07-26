

using AutoMapper;
using JobStack.Application.Common.Interfaces;
using JobStack.Application.Common.Results;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace JobStack.Application.Handlers.JobApplies.Queries;

public class GetJobApplyQuery : IRequest<IDataResult<IEnumerable<GetJobApplyQuery>>>
{
    public int Id { get; set; }
    public bool IsDeleted { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string EmailAddress { get; set; } = null!;
    public string? Description { get; set; }
    public string CvFile { get; set; } = null!;

    public IFormFile CvFileUrl { get; set; } = null!;

    public class GetJobApplyQueryHandler : IRequestHandler<GetJobApplyQuery, IDataResult<IEnumerable<GetJobApplyQuery>>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetJobApplyQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IDataResult<IEnumerable<GetJobApplyQuery>>> Handle(GetJobApplyQuery request, CancellationToken cancellationToken)
        {
            return new SuccessDataResult<IEnumerable<GetJobApplyQuery>>(
                 _mapper.Map<IEnumerable<GetJobApplyQuery>>(
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
