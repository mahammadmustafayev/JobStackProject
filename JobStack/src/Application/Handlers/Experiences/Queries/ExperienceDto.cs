using JobStack.Application.Common.Interfaces;
using JobStack.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobStack.Application.Handlers.Experiences.Queries;

public class ExperienceDto:IMapFrom<Experience>
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
