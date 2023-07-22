using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobStack.Application.Handlers.Experiences.Queries;

public class ExperienceVM
{
    public IEnumerable<ExperienceDto>? Experiences { get; set; }
}
