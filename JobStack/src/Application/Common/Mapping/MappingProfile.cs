

using AutoMapper;
using JobStack.Application.Handlers.Candidates.Commands;
using JobStack.Application.Handlers.Candidates.Commands.UpdateCandidate;
using JobStack.Application.Handlers.Candidates.Queries;
using JobStack.Application.Handlers.Categories.Commands.CreateCategory;
using JobStack.Application.Handlers.Categories.Commands.UpdateCategory;
using JobStack.Application.Handlers.Categories.Queries;
using JobStack.Application.Handlers.Cities.Commands.CreateCity;
using JobStack.Application.Handlers.Cities.Commands.UpdateCity;
using JobStack.Application.Handlers.Cities.Queries;
using JobStack.Application.Handlers.Companies.Commands;
using JobStack.Application.Handlers.Companies.Queries;
using JobStack.Application.Handlers.Countries.Commands.CreateCountry;
using JobStack.Application.Handlers.Countries.Commands.UpdateCountry;
using JobStack.Application.Handlers.Countries.Queries;
using JobStack.Application.Handlers.Experiences.Commands.CreateExperience;
using JobStack.Application.Handlers.Experiences.Commands.UpdateExperience;
using JobStack.Application.Handlers.Experiences.Queries;
using JobStack.Application.Handlers.JobApplies.Commands;
using JobStack.Application.Handlers.JobApplies.Queries;
using JobStack.Application.Handlers.JobTypes.Commands.CreateJobType;
using JobStack.Application.Handlers.JobTypes.Commands.UpdateJobType;
using JobStack.Application.Handlers.JobTypes.Queries;
using JobStack.Application.Handlers.Vacancies.Commands.CreateVacancy;
using JobStack.Application.Handlers.Vacancies.Commands.UpdateVacancy;
using JobStack.Application.Handlers.Vacancies.Queries;
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

        CreateMap<JobType, CreateJobTypeCommand>().ReverseMap();
        CreateMap<JobType, JobTypeDto>().ReverseMap();
        CreateMap<JobType, UpdateJobTypeCommand>().ReverseMap();
        CreateMap<JobType, GetJobTypesQuery>().ReverseMap();

        CreateMap<JobApply, SendJobApplytoCompany>().ReverseMap();
        CreateMap<JobApply, GetJobAppliesQuery>().ReverseMap();
        CreateMap<JobApply, JobApplyDto>().ReverseMap();
        CreateMap<JobApply, GetJobApplyQuery>().ReverseMap();


        CreateMap<Candidate, ManageCreateCandidateCommand>().ReverseMap();
        CreateMap<Candidate, CandidateDto>().ReverseMap();
        CreateMap<Candidate, GetCandidatesQuery>().ReverseMap();
        CreateMap<Candidate, GetCandidateQuery>().ReverseMap();
        CreateMap<Candidate, UpdateCandidateCommand>().ReverseMap();

        CreateMap<Company, ManageCreateCompanyCommand>().ReverseMap();
        CreateMap<Company, CompanyDto>().ReverseMap();
        CreateMap<Company, GetCompaniesQuery>().ReverseMap();
        CreateMap<Company, GetCompanyQuery>().ReverseMap();
        CreateMap<Company, UpdateCompanyCommand>().ReverseMap();

        CreateMap<Vacancy, CreateVacancyCommand>().ReverseMap();
        CreateMap<Vacancy, VacancyDto>().ReverseMap();
        CreateMap<Vacancy, GetVacanciesQuery>().ReverseMap();
        CreateMap<Vacancy, GetVacancyQuery>().ReverseMap();
        CreateMap<Vacancy, UpdateVacancyCommand>().ReverseMap();


    }


}

