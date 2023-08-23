using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using WebUI.Models;

namespace JobStack.WebUI.Areas.Manage.Controllers;

[Area("Manage")]
public class CompanyController : Controller
{
    Uri baseUrl = new("https://localhost:7264/api");
    private readonly HttpClient _client;

    public CompanyController(HttpClient client)
    {
        _client = client;
        _client.BaseAddress = baseUrl;
    }
    public IActionResult Index()
    {
        List<CompanyVM> companies = new();
        HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Companies/ManageGetAllCompanies").Result;
        if (response.IsSuccessStatusCode)
        {
            string data = response.Content.ReadAsStringAsync().Result;
            companies = JsonConvert.DeserializeObject<List<CompanyVM>>(data);
        }
        return View(companies);
    }
    public IActionResult Delete(int id)
    {
        string data = id.ToString();
        StringContent content = new(data, Encoding.UTF8, "application/json");
        HttpResponseMessage result = _client.PostAsync(_client.BaseAddress + $"/Companies/Delete?id={id}", content).Result;
        return RedirectToAction(nameof(Index));
    }
    public IActionResult PermaDelete(int id)
    {
        string data = id.ToString();
        StringContent content = new(data, Encoding.UTF8, "application/json");
        HttpResponseMessage result = _client.PostAsync(_client.BaseAddress + $"/Companies/PermaDelete?id={id}", content).Result;
        return RedirectToAction(nameof(Index));
    }
}
