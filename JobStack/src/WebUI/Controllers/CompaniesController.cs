using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebUI.Models;

namespace JobStack.WebUI.Controllers;

public class CompaniesController : Controller
{
    Uri baseUrl = new("https://localhost:7264/api");
    private readonly HttpClient _client;

    public CompaniesController(HttpClient client)
    {
        _client = client;
        _client.BaseAddress = baseUrl;
    }

    public IActionResult Index()
    {
        List<CompanyVM> companies = new();
        HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Companies/GetAllCompanies").Result;
        if (response.IsSuccessStatusCode)
        {
            string data = response.Content.ReadAsStringAsync().Result;
            companies = JsonConvert.DeserializeObject<List<CompanyVM>>(data);
        }
        return View(companies);
    }
    public IActionResult Details(int id)
    {
        List<CompanyVM> company = new();
        HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + $"/Companies/Details/{id}").Result;
        if (response.IsSuccessStatusCode)
        {
            string data = response.Content.ReadAsStringAsync().Result;
            company = JsonConvert.DeserializeObject<List<CompanyVM>>(data);
        }
        return View(company[0]);
    }
    public IActionResult SeeJob(int id)
    {
        List<CompanyVM> company = new();
        HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + $"/Companies/Details/{id}").Result;
        if (response.IsSuccessStatusCode)
        {
            string data = response.Content.ReadAsStringAsync().Result;
            company = JsonConvert.DeserializeObject<List<CompanyVM>>(data);
        }
        return View(company[0]);
    }

}
