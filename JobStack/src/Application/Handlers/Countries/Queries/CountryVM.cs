using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobStack.Application.Handlers.Countries.Queries;

public class CountryVM
{
    public IEnumerable<CountryDto>? Countries { get; set; }
}
