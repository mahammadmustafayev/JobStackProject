using AutoMapper;
using JobStack.Application.Common.Interfaces;
using JobStack.Application.Common.Results;
using MediatR;

namespace JobStack.Application.Handlers.Experiences.Queries;

public class GetExperiencesQuery : IRequest<IDataResult<ExperienceVM>>
{
    public class GetExperiencesQueryHandler : IRequestHandler<GetExperiencesQuery, IDataResult<ExperienceVM>>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;

        public GetExperiencesQueryHandler(IMapper mapper, IApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<IDataResult<ExperienceVM>> Handle(GetExperiencesQuery request, CancellationToken cancellationToken)
        {
            return null;
            //return new SuccessDataResult<ExperienceVM>(
            //    _mapper.Map<ExperienceVM>(
            //          await _context.Experiences

            //          .Include(e=>e.Candidate)
            //          .AsNoTracking()

            //          .Where(e=>e.IsDeleted==false)
            //          .ToListAsync()));
        }
    }
}
