using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using WebUI.Models;

namespace JobStack.WebUI.Areas.Manage.Controllers;

[Area("Manage")]
public class CityController : Controller
{
    Uri baseUrl = new("https://localhost:7264/api");
    private readonly HttpClient _client;

    public CityController(HttpClient client)
    {
        _client = client;
        _client.BaseAddress = baseUrl;
    }
    public IActionResult Index()
    {
        List<CityVM> cities = new();
        HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Cities/ManageGetAllCities").Result;
        if (response.IsSuccessStatusCode)
        {
            string data = response.Content.ReadAsStringAsync().Result;
            cities = JsonConvert.DeserializeObject<List<CityVM>>(data);
        }
        return View(cities);
    }
    public IActionResult Delete(int id)
    {
        string data = id.ToString();
        StringContent content = new(data, Encoding.UTF8, "application/json");
        HttpResponseMessage result = _client.PostAsync(_client.BaseAddress + $"/Cities/Delete?id={id}", content).Result;
        HttpResponseMessage response = result;
        //if (response.IsSuccessStatusCode)
        return RedirectToAction(nameof(Index));

    }
}
