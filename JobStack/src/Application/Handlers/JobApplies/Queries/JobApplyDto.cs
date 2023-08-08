namespace JobStack.Application.Handlers.JobApplies.Queries;

public class JobApplyDto
{
    public int Id { get; set; }
    public bool IsDeleted { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string EmailAddress { get; set; }
    public string? Description { get; set; }
    public string CvFile { get; set; }

    public IFormFile CvFileUrl { get; set; }
    public int VacancyId { get; set; }
    public Vacancy Vacancy { get; set; }
}
