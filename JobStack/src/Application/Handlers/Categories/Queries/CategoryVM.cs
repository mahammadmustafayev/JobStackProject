
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobStack.Application.Handlers.Categories.Queries;

public class CategoryVM
{
    public IEnumerable<CategoryDto>? Categories { get; set; }
}
