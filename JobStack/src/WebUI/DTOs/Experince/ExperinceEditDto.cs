namespace JobStack.WebUI.DTOs.Experince;

public class ExperinceEditDto
{
    public int Id { get; set; }
    public string ExperienceName { get; set; } = null!;
    public string? ExperienceDescription { get; set; }


    public DateTime? ExperienceStartYear { get; set; }

    public DateTime? ExperienceEndYear { get; set; }
}
