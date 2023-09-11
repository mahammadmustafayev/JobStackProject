using JobStack.WebUI.DTOs.Vacancy;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using WebUI.Models;

namespace JobStack.WebUI.Controllers;

public class VacanciesController : Controller
{
    Uri baseUrl = new("http://localhost:7264/api");
    private readonly HttpClient _client;
    private readonly IWebHostEnvironment _env;
    private readonly string root = Path.Combine(Directory.GetParent("JobStack").Parent.Parent.Parent.ToString(), "JobstackApp", "JobApp", "assets", "vacancies.json");


    public VacanciesController(HttpClient client, IWebHostEnvironment env)
    {
        _client = client;
        _client.BaseAddress = baseUrl;
        _env = env;
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
            return View(vacancies);

        }
        return RedirectToAction("Index", "Error");
    }
    private string JsonData()
    {
        // List<VacancyVM> vacancies = new();
        string data = "";
        HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Vacancies/GetAllVacancies").Result;
        if (response.IsSuccessStatusCode)
        {
            data = response.Content.ReadAsStringAsync().Result;
            //vacancies = JsonConvert.DeserializeObject<List<VacancyVM>>(data);
        }
        return data;
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
            ViewBag.Responsibilits = JsonConvert.DeserializeObject<string[]>(vacancies[0].ResponsibilityName);
            ViewBag.Skills = JsonConvert.DeserializeObject<string[]>(vacancies[0].SkillName);
            return View(vacancies[0]);
        }
        return RedirectToAction("Index", "Error");
    }
    [HttpGet]
    public IActionResult Create(int id)
    {
        TempData["CompanyId"] = id;
        ViewBag.Countries = CountryAll();
        ViewBag.Cities = CityAll();
        ViewBag.Categories = CategoryAll();
        ViewBag.Types = TypeAll();
        return View();
    }
    [HttpPost]
    public IActionResult Create(VacancyPostDto vacancy, string responsibilts, string skills)
    {

        VacancyPostDto vacancyPost = new()
        {
            CompanyId = (int)TempData["CompanyId"],
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
            //string root = Path.Combine(_env.ContentRootPath);
            System.IO.File.WriteAllText(root, JsonData());
            return RedirectToAction(nameof(Index));
        }
        return RedirectToAction("Index", "Error");
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
            ViewBag.Responsibility = JsonConvert.DeserializeObject<string[]>(vacancies[0].ResponsibilityName);
            ViewBag.Skillss = JsonConvert.DeserializeObject<string[]>(vacancies[0].SkillName);
            ViewBag.Countries = CountryAll();
            ViewBag.Cities = CityAll();
            ViewBag.Categories = CategoryAll();
            ViewBag.Types = TypeAll();
            TempData["VacancyId"] = id;
            return View(vacancies[0]);
        }
        return RedirectToAction("Index", "Error");
    }
    [HttpPost]
    public IActionResult Edit(VacancyUpdateDto vacancy, string responsible, string skillsebla)
    {

        VacancyUpdateDto vacancyUpdate = new()
        {
            VacancyId = (int)TempData["VacancyId"],
            TitleName = vacancy.TitleName,
            Address = vacancy.Address,
            CategoryId = vacancy.CategoryId,
            CityId = vacancy.CityId,
            CountryId = vacancy.CountryId,
            Description = vacancy.Description,
            Experience = vacancy.Experience,
            JobTypeId = vacancy.JobTypeId,
            ResponsibilityName = responsible,
            Salary = vacancy.Salary,
            SkillName = skillsebla,
        };
        string data = JsonConvert.SerializeObject(vacancyUpdate);
        StringContent content = new(data, Encoding.UTF8, "application/json");
        HttpResponseMessage result = _client.PutAsync(_client.BaseAddress + "/Vacancies/Put", content).Result;
        HttpResponseMessage response = result;
        if (response.IsSuccessStatusCode)
        {
            //System.IO.FileMode.Open;
            System.IO.File.WriteAllText(root, JsonData());
            return RedirectToAction(nameof(Index));
        }
        return RedirectToAction("Index", "Error");
    }

    public IActionResult Delete(int id)
    {
        string data = id.ToString();
        StringContent content = new(data, Encoding.UTF8, "application/json");
        HttpResponseMessage result = _client.PostAsync(_client.BaseAddress + $"/Vacancies/Delete?id={id}", content).Result;
        if (result.IsSuccessStatusCode)
        {
            System.IO.File.WriteAllText(root, JsonData());
            return RedirectToAction(nameof(Index));
        }
        return RedirectToAction("Index", "Error");
    }
}

