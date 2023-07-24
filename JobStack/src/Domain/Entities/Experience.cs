


using JobStack.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace JobStack.Domain.Entities;

public class Experience : BaseAuditableEntity
{
    public string ExperienceName { get; set; } = null!;
    public string? ExperienceDescription { get; set; }



    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy}")]
    public DateTime? ExperienceStartYear { get; set; }

    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy}")]
    public DateTime? ExperienceEndYear { get; set; }

    public int CandidateId { get; set; }
    public Candidate Candidate { get; set; } = null!;
}
