

using AutoMapper;
using JobStack.Application.Common.Interfaces;
using JobStack.Application.Common.Results;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobStack.Application.Handlers.JobApplies.Queries;

public class GetJobAppliesQuery:IRequest<IDataResult<IEnumerable<GetJobAppliesQuery>>>
{
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string EmailAddress { get; set; } = null!;
    public string? Description { get; set; }
    public string CvFile { get; set; } = null!;
    [NotMapped]
    public IFormFile CvFileUrl { get; set; } = null!;

    public class GetJobAppliesQueryHandler : IRequestHandler<GetJobAppliesQuery, IDataResult<IEnumerable<GetJobAppliesQuery>>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetJobAppliesQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IDataResult<IEnumerable<GetJobAppliesQuery>>> Handle(GetJobAppliesQuery request, CancellationToken cancellationToken)
        {
            return new SuccessDataResult<IEnumerable<GetJobAppliesQuery>>(
                 _mapper.Map<IEnumerable<GetJobAppliesQuery>>(
                     await _context.JobApplies

                     .Include(j => j.Vacancy)
                     .ThenInclude(j=>j.Company)
                     .AsNoTracking()
                     
                     .Where(j => j.IsDeleted == false)
                     .ToListAsync()
                     ));
        }
    }
}
