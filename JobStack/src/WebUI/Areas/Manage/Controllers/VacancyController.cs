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

    public VacancyController(HttpClient client)
    {
        _client = client;
        _client.BaseAddress = baseUrl;
    }

    public IActionResult Index()
    {
        List<VacancyVM> vacancies = new();
        HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Vacancies/ManageGetAllVacancies").Result;
        if (response.IsSuccessStatusCode)
        {
            string data = response.Content.ReadAsStringAsync().Result;
            vacancies = JsonConvert.DeserializeObject<List<VacancyVM>>(data);
        }
        return View(vacancies);
    }
    public IActionResult Delete(int id)
    {
        string data = id.ToString();
        StringContent content = new(data, Encoding.UTF8, "application/json");
        HttpResponseMessage result = _client.PostAsync(_client.BaseAddress + $"/Vacancies/Delete?id={id}", content).Result;
        return RedirectToAction(nameof(Index));
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
        }
        ViewBag.Responsibilits = JsonConvert.DeserializeObject<string[]>(vacancies[0].ResponsibilityName);
        ViewBag.Skills = JsonConvert.DeserializeObject<string[]>(vacancies[0].SkillName);
        return View(vacancies[0]);
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
            return RedirectToAction(nameof(Index));
        }
        return View();
    }
}
