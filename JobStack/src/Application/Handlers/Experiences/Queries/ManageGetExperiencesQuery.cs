namespace JobStack.Application.Handlers.Experiences.Queries;

public class ManageGetExperiencesQuery : IRequest<IDataResult<IEnumerable<ExperienceDto>>>
{
    public class ManageGetExperiencesQueryHandler : IRequestHandler<ManageGetExperiencesQuery, IDataResult<IEnumerable<ExperienceDto>>>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;

        public ManageGetExperiencesQueryHandler(IMapper mapper, IApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<IDataResult<IEnumerable<ExperienceDto>>> Handle(ManageGetExperiencesQuery request, CancellationToken cancellationToken)
        {

            return new SuccessDataResult<IEnumerable<ExperienceDto>>(
                _mapper.Map<IEnumerable<ExperienceDto>>(
                      await _context.Experiences

                      //.Include(e => e.Candidate)
                      //.AsNoTracking()

                      .ToListAsync()));
        }
    }
}
