



using JobStack.Application.Handlers.Candidates.Commands.CreateCandidate;

namespace JobStack.Application.Common.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Category, Handlers.Categories.Commands.CreateCategory.ManageCreateCategoryCommand>().ReverseMap();
        CreateMap<Category, Handlers.Categories.Commands.ManageCreateCategoryCommandTest>().ReverseMap();
        CreateMap<Category, CategoryDto>().ReverseMap();
        CreateMap<Category, UpdateCategoryCommand>().ReverseMap();
        CreateMap<Category, GetCategoriesQuery>().ReverseMap();
        CreateMap<Category, GetCategoriesCountQuery>().ReverseMap();

        CreateMap<City, CreateCityCommand>().ReverseMap();
        CreateMap<City, CityDto>().ReverseMap();
        CreateMap<City, UpdateCityCommand>().ReverseMap();
        CreateMap<City, GetCitiesQuery>().ReverseMap();
        CreateMap<City, GetCityQuery>().ReverseMap();

        //CreateMap<UserLogin, UserLoginCommand>().ReverseMap();

        CreateMap<Country, CreateCountryCommand>().ReverseMap();
        CreateMap<Country, CountryDto>().ReverseMap();
        CreateMap<Country, UpdateCountryCommand>().ReverseMap();
        CreateMap<Country, GetCountriesQuery>().ReverseMap();
        CreateMap<Country, GetCountryQuery>().ReverseMap();

        CreateMap<Experience, CreateExperienceCommand>().ReverseMap();
        CreateMap<Experience, ExperienceDto>().ReverseMap();
        CreateMap<Experience, UpdateExperienceCommand>().ReverseMap();
        CreateMap<Experience, GetExperienceQuery>().ReverseMap();
        CreateMap<Experience, GetExperiencesQuery>().ReverseMap();

        CreateMap<JobType, CreateJobTypeCommand>().ReverseMap();
        CreateMap<JobType, JobTypeDto>().ReverseMap();
        CreateMap<JobType, UpdateJobTypeCommand>().ReverseMap();
        CreateMap<JobType, GetJobTypesQuery>().ReverseMap();
        CreateMap<JobType, GetJobTypeQuery>().ReverseMap();

        CreateMap<JobApply, SendJobApplytoCompany>().ReverseMap();
        CreateMap<JobApply, GetJobAppliesQuery>().ReverseMap();
        CreateMap<JobApply, JobApplyDto>().ReverseMap();
        CreateMap<JobApply, GetJobApplyQuery>().ReverseMap();


        CreateMap<Candidate, ManageCreateCandidateCommand>().ReverseMap();
        CreateMap<Candidate, CreateCandidateCommand>().ReverseMap();
        CreateMap<Candidate, CandidateDto>().ReverseMap();
        CreateMap<Candidate, GetCandidatesQuery>().ReverseMap();
        CreateMap<Candidate, GetCandidateQuery>().ReverseMap();
        CreateMap<Candidate, UpdateCandidateCommand>().ReverseMap();
        CreateMap<Candidate, RegisterCandidateCommand>().ReverseMap();

        CreateMap<Company, ManageCreateCompanyCommand>().ReverseMap();
        CreateMap<Company, CompanyDto>().ReverseMap();
        CreateMap<Company, GetCompaniesQuery>().ReverseMap();
        CreateMap<Company, GetCompaniesCountQuery>().ReverseMap();
        CreateMap<Company, GetCompanyQuery>().ReverseMap();
        CreateMap<Company, UpdateCompanyCommand>().ReverseMap();
        CreateMap<Company, RegisterCompanyCommand>().ReverseMap();

        CreateMap<Vacancy, CreateVacancyCommand>().ReverseMap();
        CreateMap<Vacancy, VacancyDto>().ReverseMap();
        CreateMap<Vacancy, GetVacanciesQuery>().ReverseMap();
        CreateMap<Vacancy, GetCountVacanciesQuery>().ReverseMap();
        CreateMap<Vacancy, GetVacancyQuery>().ReverseMap();
        CreateMap<Vacancy, UpdateVacancyCommand>().ReverseMap();




    }


}

