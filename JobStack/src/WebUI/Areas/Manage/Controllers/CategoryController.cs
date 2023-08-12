using JobStack.WebUI.Areas.Manage.ViewModels.Category;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using WebUI.Models;

namespace JobStack.WebUI.Areas.Manage.Controllers;

[Area("Manage")]
public class CategoryController : Controller
{
    Uri baseUrl = new("http://localhost:7264/api");
    private readonly HttpClient _client;

    public CategoryController(HttpClient client)
    {
        _client = client;
        _client.BaseAddress = baseUrl;
    }

    public IActionResult Index()
    {
        List<CategoryVM> categories = new();
        HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Categories/ManageGetAllCategories").Result;
        if (response.IsSuccessStatusCode)
        {
            string data = response.Content.ReadAsStringAsync().Result;
            categories = JsonConvert.DeserializeObject<List<CategoryVM>>(data);
        }
        return View(categories);
    }
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Create(CategoryPostDto category)
    {
        //string data = JsonConvert.SerializeObject(category);
        //StringContent content = new(data, Encoding.UTF8, "application/json");
        //HttpResponseMessage response = _client.PostAsJsonAsync(_client.BaseAddress + "/Categories/Post", content).Result;
        //if (response.IsSuccessStatusCode)
        //{
        //    return RedirectToAction(nameof(Index));
        //}
        return View();



    }
    public IActionResult Edit()
    {
        return View();
    }
    public IActionResult Delete()
    {
        return View();
    }
    public IActionResult PermaDelete()
    {
        return View();
    }

}
