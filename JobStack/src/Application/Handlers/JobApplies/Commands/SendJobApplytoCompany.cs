namespace JobStack.Application.Handlers.JobApplies.Commands;

public record SendJobApplytoCompany
    (
       int VacancyId,
       string FirstName,
      string LastName,
      string EmailAddress,
      string? Description,
      string? CvFileUrl
    ) : IRequest<IDataResult<SendJobApplytoCompany>>
{
    public class SendJobApplytoCompanyHandler : IRequestHandler<SendJobApplytoCompany, IDataResult<SendJobApplytoCompany>>
    {

        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;
        private readonly IHostEnvironment _env;
        private readonly IEmailService _emailService;

        public SendJobApplytoCompanyHandler(IMapper mapper, IApplicationDbContext context, IHostEnvironment env, IEmailService emailService = null)
        {
            _mapper = mapper;
            _context = context;
            _env = env;
            _emailService = emailService;
        }

        public async Task<IDataResult<SendJobApplytoCompany>> Handle(SendJobApplytoCompany request, CancellationToken cancellationToken)
        {

            JobApply jobApply = _mapper.Map<JobApply>(request);





            jobApply.EmailAddress = request.EmailAddress;
            jobApply.FirstName = request.FirstName;
            jobApply.LastName = request.LastName;
            jobApply.Description = request.Description;
            jobApply.CvFile = request.CvFileUrl;
            jobApply.VacancyId = request.VacancyId;
            _emailService.SendEmail(request.EmailAddress,
                $"""
                <h3 style="font-size: 20px;font-family: system-ui, -apple-system, BlinkMacSystemFont, 'Segoe UI', Roboto, Oxygen, Ubuntu, Cantarell, 'Open Sans', 'Helvetica Neue', sans-serif;">Dəyərli {request.FirstName} {request.LastName}</h3>
                <p style="font-size: 10px;" >Müraciətiniz üçün təşəkkür edirik.Müraciət etdiniz vakansiya əgər qəbul edilərsə sizinlə vakansiya verən şirkət tərəfindən  əlaqə qurulacaq.</p>
                <p>Hörmətlə</p>
                <p>JobStack Managment</p>
                <img  src="https://shreethemes.in/jobstack/layouts/assets/images/logo-dark.png" style="width: 200px;height: 45px; ">
                """);
            //await _context.JobApplies.Where(j => j.Id == request.VacancyId);
            await _context.JobApplies.AddAsync(jobApply);

            await _context.SaveChangesAsync(cancellationToken);
            return new SuccessDataResult<SendJobApplytoCompany>(request, Messages.SendEmailMessages);
        }
    }
}
