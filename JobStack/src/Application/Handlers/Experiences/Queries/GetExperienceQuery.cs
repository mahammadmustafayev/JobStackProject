namespace JobStack.Application.Handlers.Experiences.Queries;

public record GetExperienceQuery(int id) : IRequest<IDataResult<IEnumerable<ExperienceDto>>>
{
    public class GetExperienceQueryHandler : IRequestHandler<GetExperienceQuery, IDataResult<IEnumerable<ExperienceDto>>>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;

        public GetExperienceQueryHandler(IMapper mapper, IApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<IDataResult<IEnumerable<ExperienceDto>>> Handle(GetExperienceQuery request, CancellationToken cancellationToken)
        {

            return new SuccessDataResult<IEnumerable<ExperienceDto>>(
                _mapper.Map<IEnumerable<ExperienceDto>>(
                      await _context.Experiences

                      .Include(e => e.Candidate)
                      .AsNoTracking()
                      .Where(e => e.Id == request.id)
                      .Where(e => e.IsDeleted == false)
                      .ToListAsync()));
        }
    }
}
