namespace JobStack.Application.Handlers.JobApplies.Validations;

public class SendJobApplytoCompanyValidator : AbstractValidator<SendJobApplytoCompany>
{
    public SendJobApplytoCompanyValidator()
    {
        RuleFor(j => j.EmailAddress).NotEmpty();
        RuleFor(j => j.FirstName).NotEmpty();
        RuleFor(j => j.LastName).NotEmpty();
        RuleFor(j => j.Description);
        RuleFor(j => j.CvFileUrl);
    }
}
