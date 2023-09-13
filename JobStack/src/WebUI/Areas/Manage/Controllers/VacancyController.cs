using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using WebUI.Models;

namespace JobStack.WebUI.Areas.Manage.Controllers;

[Area("Manage")]
public class VacancyController : Controller
{
    Uri baseUrl = new("http://localhost:7264/api");
    private readonly HttpClient _client;
    private readonly IWebHostEnvironment _env;
    private readonly string root = Path.Combine(Directory.GetParent("JobStack").Parent.Parent.Parent.ToString(), "JobstackApp", "JobApp", "assets", "vacancies.json");


    public VacancyController(HttpClient client, IWebHostEnvironment env)
    {
        _client = client;
        _client.BaseAddress = baseUrl;
        _env = env;
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

    public IActionResult Index()
    {
        List<VacancyVM> vacancies = new();
        HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Vacancies/ManageGetAllVacancies").Result;
        if (response.IsSuccessStatusCode)
        {
            string data = response.Content.ReadAsStringAsync().Result;
            vacancies = JsonConvert.DeserializeObject<List<VacancyVM>>(data);
            System.IO.File.WriteAllText(root, JsonData());
            return View(vacancies);
        }
        return RedirectToAction("Index", "Errors");

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
        return RedirectToAction("Index", "Errors");

    }
    [HttpGet]
    public IActionResult PermaDelete(int id)
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
        return RedirectToAction("Index", "Errors");

    }
    [HttpPost, ActionName(nameof(PermaDelete))]
    public IActionResult DeleteConfirmed(int id)
    {
        string data = id.ToString();
        StringContent content = new(data, Encoding.UTF8, "application/json");
        HttpResponseMessage result = _client.PostAsync(_client.BaseAddress + $"/Vacancies/PermaDelete?id={id}", content).Result;
        HttpResponseMessage response = result;
        if (response.IsSuccessStatusCode)
        {
            System.IO.File.WriteAllText(root, JsonData());
            return RedirectToAction(nameof(Index));
        }
        return RedirectToAction("Index", "Errors");
    }
}
