using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobStack.Application.Handlers.Cities.Queries;

public class CityVM
{
    public IEnumerable<CityDto>? Cities { get; set; }
}
