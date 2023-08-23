using JobStack.WebUI.Areas.Manage.ViewModels.Category;
using JobStack.WebUI.DTOs.Category;
using JobStack.WebUI.Utilities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using WebUI.Models;

namespace JobStack.WebUI.Areas.Manage.Controllers;

[Area("Manage")]

public class CategoryController : Controller
{
    Uri baseUrl = new("https://localhost:7264/api");
    private readonly HttpClient _client;
    private readonly IWebHostEnvironment _env;
    public CategoryController(HttpClient client, IWebHostEnvironment env)
    {
        _client = client;
        _client.BaseAddress = baseUrl;
        _env = env;
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
        var folderPath = Path.Combine(_env.WebRootPath, "data", "category");
        string returnPath = category.Photo.SaveFile(folderPath);

        CategoryDto categoryDto = new CategoryDto()
        {
            CategoryName = category.CategoryName,
            Photo = returnPath
        };


        string data = JsonConvert.SerializeObject(categoryDto);
        StringContent content = new(data, Encoding.UTF8, "application/json");
        HttpResponseMessage result = _client.PostAsync(_client.BaseAddress + "/Categories/Create", content).Result;
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
        List<CategoryEditDto> category = new();
        HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + $"/Categories/Details/{id}").Result;
        if (response.IsSuccessStatusCode)
        {
            string data = response.Content.ReadAsStringAsync().Result;
            category = JsonConvert.DeserializeObject<List<CategoryEditDto>>(data);
        }
        TempData["OldImage"] = category[0].Logo;
        return View(category[0]);
    }
    [HttpPost]
    public IActionResult Edit(CategoryEditDto categoryEdit)
    {
        var folderPath = Path.Combine(_env.WebRootPath, "data", "category");
        string returnPath = categoryEdit.Photo.SaveFile(folderPath);
        CategoryUpdateDto update = new CategoryUpdateDto()
        {
            CategoryName = categoryEdit.CategoryName,
            CategoryId = categoryEdit.Id,
            Logo = returnPath
        };
        string data = JsonConvert.SerializeObject(update);
        StringContent content = new(data, Encoding.UTF8, "application/json");
        HttpResponseMessage result = _client.PutAsync(_client.BaseAddress + "/Categories/Put", content).Result;
        HttpResponseMessage response = result;
        if (response.IsSuccessStatusCode)
        {
            string OldPicture = TempData["OldImage"] as string;
            var fullPath = Path.Combine(folderPath, OldPicture);
            if (System.IO.File.Exists(fullPath)) System.IO.File.Delete(fullPath);
            return RedirectToAction(nameof(Index));
        }
        return View(categoryEdit);
    }
    public IActionResult Delete(int id)
    {
        string data = id.ToString();
        StringContent content = new(data, Encoding.UTF8, "application/json");
        HttpResponseMessage result = _client.PostAsync(_client.BaseAddress + $"/Categories/Delete?id={id}", content).Result;
        return RedirectToAction(nameof(Index));
    }
    [HttpGet]
    public IActionResult PermaDelete(int id)
    {
        List<CategoryEditDto> category = new();
        HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + $"/Categories/Details/{id}").Result;
        if (response.IsSuccessStatusCode)
        {
            string data = response.Content.ReadAsStringAsync().Result;
            category = JsonConvert.DeserializeObject<List<CategoryEditDto>>(data);
        }
        return View(category[0]);
    }
    [HttpPost, ActionName(nameof(PermaDelete))]
    public IActionResult DeleteConfirmed(int id)
    {
        string data = id.ToString();
        StringContent content = new(data, Encoding.UTF8, "application/json");
        HttpResponseMessage result = _client.PostAsync(_client.BaseAddress + $"/Categories/PermaDelete?id={id}", content).Result;
        return RedirectToAction(nameof(Index));

    }

}
