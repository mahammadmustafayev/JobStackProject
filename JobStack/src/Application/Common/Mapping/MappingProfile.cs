

using AutoMapper;
using JobStack.Application.Handlers.Categories.Commands.CreateCategory;
using JobStack.Application.Handlers.Categories.Commands.UpdateCategory;
using JobStack.Application.Handlers.Categories.Queries;
using JobStack.Application.Handlers.Cities.Commands.CreateCity;
using JobStack.Application.Handlers.Cities.Commands.UpdateCity;
using JobStack.Application.Handlers.Cities.Queries;
using JobStack.Application.Handlers.Countries.Commands.CreateCountry;
using JobStack.Application.Handlers.Countries.Commands.UpdateCountry;
using JobStack.Application.Handlers.Countries.Queries;
using JobStack.Application.Handlers.Experiences.Commands.CreateExperience;
using JobStack.Application.Handlers.Experiences.Commands.UpdateExperience;
using JobStack.Application.Handlers.Experiences.Queries;
using JobStack.Domain.Entities;

namespace JobStack.Application.Common.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Category, CreateCategoryCommand>().ReverseMap();
        CreateMap<Category, CategoryDto>().ReverseMap();
        CreateMap<Category, UpdateCategoryCommand>().ReverseMap();
        CreateMap<Category, GetCategoriesQuery>().ReverseMap();

        CreateMap<City, CreateCityCommand>().ReverseMap();
        CreateMap<City, CityDto>().ReverseMap();
        CreateMap<City, UpdateCityCommand>().ReverseMap();
        CreateMap<City, GetCitiesQuery>().ReverseMap();

        CreateMap<Country, CreateCountryCommand>().ReverseMap();
        CreateMap<Country, CountryDto>().ReverseMap();
        CreateMap<Country, UpdateCountryCommand>().ReverseMap();
        CreateMap<Country, GetCountriesQuery>().ReverseMap();

        CreateMap<Experience, CreateExperienceCommand>().ReverseMap();
        CreateMap<Experience, ExperienceDto>().ReverseMap();
        CreateMap<Experience, UpdateExperienceCommand>().ReverseMap();
        CreateMap<Experience, GetExperienceQuery>().ReverseMap();
        CreateMap<Experience, GetExperiencesQuery>().ReverseMap();
    }


}

