namespace JobStack.WebUI.ViewModels.JobApply;

public class JobApplyPostDto
{
    public int VacancyId { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string EmailAddress { get; set; } = null!;
    public string? Description { get; set; }
    public IFormFile? CvFileUrl { get; set; }
}
