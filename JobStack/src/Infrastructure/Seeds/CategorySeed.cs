using JobStack.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobStack.Infrastructure.Seeds;

public static class CategorySeed
{
    public static List<Category> CategoriesData = new()
    {
        new Category
        {
            CategoryName="Business"
        },
        new Category
        {
            CategoryName="Programmer"
        },
        new Category
        {
            CategoryName="Healthy"
        }, 
        new Category
        {
            CategoryName="Web Designer"
        },
        new Category
        {
            CategoryName="Web Developer"
        },
        new Category
        {
            CategoryName="UI/ UX Designer"
        },
    };
}
