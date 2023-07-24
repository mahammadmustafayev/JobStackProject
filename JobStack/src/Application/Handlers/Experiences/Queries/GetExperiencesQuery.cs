using AutoMapper;
using JobStack.Application.Common.Interfaces;
using JobStack.Application.Common.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace JobStack.Application.Handlers.Experiences.Queries;

public class GetExperiencesQuery : IRequest<IDataResult<IEnumerable<ExperienceDto>>>
{
    public class GetExperiencesQueryHandler : IRequestHandler<GetExperiencesQuery, IDataResult<IEnumerable<ExperienceDto>>>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;

        public GetExperiencesQueryHandler(IMapper mapper, IApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<IDataResult<IEnumerable<ExperienceDto>>> Handle(GetExperiencesQuery request, CancellationToken cancellationToken)
        {

            return new SuccessDataResult<IEnumerable<ExperienceDto>>(
                _mapper.Map<IEnumerable<ExperienceDto>>(
                      await _context.Experiences

                      .Include(e => e.Candidate)
                      .AsNoTracking()

                      .Where(e => e.IsDeleted == false)
                      .ToListAsync()));
        }
    }
}
