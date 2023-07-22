using AutoMapper;
using JobStack.Application.Common.Interfaces;
using JobStack.Application.Common.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace JobStack.Application.Handlers.Experiences.Queries;

public  record GetExperienceQuery(int id):IRequest<IDataResult<ExperienceVM>>
{
    public class GetExperienceQueryHandler : IRequestHandler<GetExperienceQuery, IDataResult<ExperienceVM>>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;

        public GetExperienceQueryHandler(IMapper mapper, IApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<IDataResult<ExperienceVM>> Handle(GetExperienceQuery request, CancellationToken cancellationToken)
        {
            return new SuccessDataResult<ExperienceVM>(
                _mapper.Map<ExperienceVM>(
                      await _context.Experiences

                      .Include(e => e.Candidate)
                      .AsNoTracking()
                      .Where(e=>e.Id==request.id)
                      .Where(e => e.IsDeleted == false)
                      .ToListAsync()));
        }
    }
}
