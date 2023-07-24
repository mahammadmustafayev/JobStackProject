using System.ComponentModel.DataAnnotations;

namespace JobStack.Application.Handlers.Experiences.Queries;

public class ExperienceDto
{
    public int Id { get; set; }
    public bool IsDeleted { get; set; }
    public string ExperienceName { get; set; }
    public string ExperienceDescription { get; set; }



    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy}")]
    public DateTime ExperienceStartYear { get; set; }

    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy}")]
    public DateTime ExperienceEndYear { get; set; }
}
