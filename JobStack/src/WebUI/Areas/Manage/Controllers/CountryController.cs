using JobStack.WebUI.Areas.Manage.ViewModels.Country;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using WebUI.Models;

namespace JobStack.WebUI.Areas.Manage.Controllers;
[Area("Manage")]

public class CountryController : Controller
{
    Uri baseUrl = new("http://localhost:7264/api");
    private readonly HttpClient _client;

    public CountryController(HttpClient client)
    {
        _client = client;
        _client.BaseAddress = baseUrl;
    }

    public IActionResult Index()
    {
        List<CountryVM> countries = new();
        HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Countries/ManageGetAllCountries").Result;
        if (response.IsSuccessStatusCode)
        {
            string data = response.Content.ReadAsStringAsync().Result;
            countries = JsonConvert.DeserializeObject<List<CountryVM>>(data);
        }
        return View(countries);
    }
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Create(CountryDto country)
    {
        string data = JsonConvert.SerializeObject(country);
        StringContent content = new(data, Encoding.UTF8, "application/json");
        HttpResponseMessage result = _client.PostAsync(_client.BaseAddress + "/Countries/Post", content).Result;
        HttpResponseMessage response = result;
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction(nameof(Index));
        }
        return View();
    }
    [HttpGet]
    public IActionResult Edit(int id)
    {
        List<CountryEditDto> item = new();
        HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + $"/Countries/Details/{id}").Result;
        if (response.IsSuccessStatusCode)
        {
            string data = response.Content.ReadAsStringAsync().Result;
            item = JsonConvert.DeserializeObject<List<CountryEditDto>>(data);
        }
        return View(item[0]);
    }
    [HttpPost]
    public IActionResult Edit(CountryEditDto country)
    {
        string data = JsonConvert.SerializeObject(country);
        StringContent content = new(data, Encoding.UTF8, "application/json");
        HttpResponseMessage result = _client.PutAsync(_client.BaseAddress + "/Countries/Put", content).Result;
        HttpResponseMessage response = result;
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction(nameof(Index));
        }
        return View(country);
    }
    public IActionResult Delete(int id)
    {
        string data = id.ToString();
        StringContent content = new(data, Encoding.UTF8, "application/json");
        HttpResponseMessage result = _client.PostAsync(_client.BaseAddress + $"/Countries/Delete?id={id}", content).Result;
        HttpResponseMessage response = result;
        //if (response.IsSuccessStatusCode)
        return RedirectToAction(nameof(Index));

    }
    [HttpGet]
    public IActionResult PermaDelete(int id)
    {
        List<CountryDto> item = new();
        HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + $"Countries/Details/{id}").Result;
        if (response.IsSuccessStatusCode)
        {
            string data = response.Content.ReadAsStringAsync().Result;
            item = JsonConvert.DeserializeObject<List<CountryDto>>(data);
        }
        return View(item[0]);
    }

    // /JobTypes/Delete/6
    [HttpPost, ActionName(nameof(PermaDelete))]
    public IActionResult DeleteConfirmed(int id)
    {
        string data = id.ToString();
        StringContent content = new(data, Encoding.UTF8, "application/json");
        HttpResponseMessage result = _client.PostAsync(_client.BaseAddress + $"/Countries/PermaDelete?id={id}", content).Result;
        HttpResponseMessage response = result;
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction(nameof(Index));
        }
        return View();
    }
}
