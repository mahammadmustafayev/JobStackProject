using JobStack.WebUI.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebUI.Models;

public class JobApplyVM : BaseAuditableEntityVM
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string EmailAddress { get; set; } = null!;
    public string? Description { get; set; }
    public string? CvFile { get; set; }
    [NotMapped]
    public IFormFile? CvFileUrl { get; set; }

    public int VacancyId { get; set; }
    public VacancyVM? Vacancy { get; set; }
}
