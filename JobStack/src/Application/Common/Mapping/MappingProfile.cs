

using AutoMapper;
using JobStack.Application.Handlers.Categories.Commands.CreateCategory;
using JobStack.Application.Handlers.Categories.Commands.UpdateCategory;
using JobStack.Application.Handlers.Categories.Queries;
using JobStack.Domain.Entities;

namespace JobStack.Application.Common.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Category, CreateCategoryCommand>().ReverseMap();
        CreateMap<Category, CategoryVM>().ReverseMap();
        CreateMap<Category, CategoryDto>().ReverseMap();
        CreateMap<Category, UpdateCategoryCommand>().ReverseMap();
        CreateMap<Category, GetCategoriesQuery>().ReverseMap();
    }


}

