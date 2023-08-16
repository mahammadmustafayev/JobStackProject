using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebUI.Models;

namespace JobStack.WebUI.Controllers;

public class VacanciesController : Controller
{
    Uri baseUrl = new("http://localhost:7264/api");
    private readonly HttpClient _client;

    public VacanciesController(HttpClient client)
    {
        _client = client;
        _client.BaseAddress = baseUrl;

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
    public IActionResult Post()
    {
        return View();
    }
}

