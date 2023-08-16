namespace JobStack.WebUI.DTOs.JobApply;

public class JobApplyDto
{
    public int VacancyId { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string EmailAddress { get; set; } = null!;
    public string? Description { get; set; }
    public string? CvFileUrl { get; set; }
}
