using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebUI.Models;

namespace JobStack.WebUI.Controllers;

public class CategoriesController : Controller
{
    Uri baseUrl = new("https://localhost:7264/api");
    private readonly HttpClient _client;

    public CategoriesController(HttpClient client)
    {
        _client = client;
        _client.BaseAddress = baseUrl;
    }

    public IActionResult Index()
    {
        List<CategoryVM> categories = new();
        HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Categories/GetAllCategories").Result;
        if (response.IsSuccessStatusCode)
        {
            string data = response.Content.ReadAsStringAsync().Result;
            categories = JsonConvert.DeserializeObject<List<CategoryVM>>(data);
            return View(categories);
        }
        return RedirectToAction("Index", "Error");
    }
}
