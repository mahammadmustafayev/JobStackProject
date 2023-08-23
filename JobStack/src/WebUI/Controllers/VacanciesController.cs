using JobStack.WebUI.DTOs.Vacancy;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using WebUI.Models;

namespace JobStack.WebUI.Controllers;

public class VacanciesController : Controller
{
    Uri baseUrl = new("https://localhost:7264/api");
    private readonly HttpClient _client;

    public VacanciesController(HttpClient client)
    {
        _client = client;
        _client.BaseAddress = baseUrl;

    }
    private List<CountryVM> CountryAll()
    {
        List<CountryVM> countries = new();
        HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Countries/GetAllCountries").Result;
        if (response.IsSuccessStatusCode)
        {
            string data = response.Content.ReadAsStringAsync().Result;
            countries = JsonConvert.DeserializeObject<List<CountryVM>>(data);
        }
        return countries;
    }
    private List<CityVM> CityAll()
    {
        List<CityVM> cities = new();
        HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Cities/GetAllCities").Result;
        if (response.IsSuccessStatusCode)
        {
            string data = response.Content.ReadAsStringAsync().Result;
            cities = JsonConvert.DeserializeObject<List<CityVM>>(data);
        }
        return cities;
    }
    private List<CategoryVM> CategoryAll()
    {
        List<CategoryVM> categories = new();
        HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Categories/GetAllCategories").Result;
        if (response.IsSuccessStatusCode)
        {
            string data = response.Content.ReadAsStringAsync().Result;
            categories = JsonConvert.DeserializeObject<List<CategoryVM>>(data);
        }
        return categories;
    }
    private List<JobTypeVM> TypeAll()
    {
        List<JobTypeVM> jobTypes = new();
        HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/JobTypes/GetAllTypes").Result;
        if (response.IsSuccessStatusCode)
        {
            string data = response.Content.ReadAsStringAsync().Result;
            jobTypes = JsonConvert.DeserializeObject<List<JobTypeVM>>(data);
        }
        return jobTypes;
    }
    public IActionResult Index()
    {
        List<VacancyVM> vacancies = new();
        HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Vacancies/GetAllVacancies").Result;
        if (response.IsSuccessStatusCode)
        {
            string data = response.Content.ReadAsStringAsync().Result;
            vacancies = JsonConvert.DeserializeObject<List<VacancyVM>>(data);
        }
        return View(vacancies);
    }
    [HttpGet]
    public IActionResult Details(int id)
    {
        List<VacancyVM> vacancies = new();
        HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + $"/Vacancies/Details/{id}").Result;
        if (response.IsSuccessStatusCode)
        {
            string data = response.Content.ReadAsStringAsync().Result;
            vacancies = JsonConvert.DeserializeObject<List<VacancyVM>>(data);
        }
        ViewBag.Responsibilits = JsonConvert.DeserializeObject<string[]>(vacancies[0].ResponsibilityName);
        ViewBag.Skills = JsonConvert.DeserializeObject<string[]>(vacancies[0].SkillName);
        return View(vacancies[0]);
    }
    [HttpGet]
    public IActionResult Create()
    {

        ViewBag.Countries = CountryAll();
        ViewBag.Cities = CityAll();
        ViewBag.Categories = CategoryAll();
        ViewBag.Types = TypeAll();
        return View();
    }
    [HttpPost]
    public IActionResult Create(int id, VacancyPostDto vacancy, string responsibilts, string skills)
    {
        VacancyPostDto vacancyPost = new()
        {
            CompanyId = id,
            Address = vacancy.Address,
            CategoryId = vacancy.CategoryId,
            CityId = vacancy.CityId,
            CountryId = vacancy.CountryId,
            Description = vacancy.Description,
            Experience = vacancy.Experience,
            JobTypeId = vacancy.JobTypeId,
            ResponsibilityName = responsibilts,
            Salary = vacancy.Salary,
            SkillName = skills,
            TitleName = vacancy.TitleName
        };
        string data = JsonConvert.SerializeObject(vacancyPost);
        StringContent content = new(data, Encoding.UTF8, "application/json");
        HttpResponseMessage response = _client.PostAsync(_client.BaseAddress + "/Vacancies/Post", content).Result;
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction(nameof(Index));
        }
        return View();
    }
    [HttpGet]
    public IActionResult Edit(int id)
    {
        List<VacancyUpdateDto> vacancies = new();
        HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + $"/Vacancies/Details/{id}").Result;
        if (response.IsSuccessStatusCode)
        {
            string data = response.Content.ReadAsStringAsync().Result;
            vacancies = JsonConvert.DeserializeObject<List<VacancyUpdateDto>>(data);
        }
        ViewBag.Responsibility = JsonConvert.DeserializeObject<string[]>(vacancies[0].ResponsibilityName);
        ViewBag.Skillss = JsonConvert.DeserializeObject<string[]>(vacancies[0].SkillName);
        ViewBag.Countries = CountryAll();
        ViewBag.Cities = CityAll();
        ViewBag.Categories = CategoryAll();
        ViewBag.Types = TypeAll();
        TempData["VacancyId"] = id;
        return View(vacancies[0]);
    }
    [HttpPost]
    public IActionResult Edit(VacancyUpdateDto vacancy, string responsibilts, string skills)
    {
        VacancyUpdateDto vacancyUpdate = new()
        {
            VacancyId = Convert.ToInt32(TempData["VacancyId"]),
            TitleName = vacancy.TitleName,
            Address = vacancy.Address,
            CategoryId = vacancy.CategoryId,
            CityId = vacancy.CityId,
            CountryId = vacancy.CountryId,
            Description = vacancy.Description,
            Experience = vacancy.Experience,
            JobTypeId = vacancy.JobTypeId,
            ResponsibilityName = responsibilts,
            Salary = vacancy.Salary,
            SkillName = skills,
        };
        string data = JsonConvert.SerializeObject(vacancyUpdate);
        StringContent content = new(data, Encoding.UTF8, "application/json");
        HttpResponseMessage result = _client.PutAsync(_client.BaseAddress + "/Vacancies/Put", content).Result;
        HttpResponseMessage response = result;
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction(nameof(Index));
        }
        return View(vacancyUpdate);
    }

    public IActionResult Delete(int id)
    {
        string data = id.ToString();
        StringContent content = new(data, Encoding.UTF8, "application/json");
        HttpResponseMessage result = _client.PostAsync(_client.BaseAddress + $"/Vacancies/Delete?id={id}", content).Result;
        return RedirectToAction(nameof(Index));
    }
}

