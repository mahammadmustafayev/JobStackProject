
using JobStack.WebUI.ViewModels.Home;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebUI.Models;

namespace WebUI.Controllers;

public class HomeController : Controller
{
    Uri baseUrl = new("https://localhost:7264/api");
    private readonly HttpClient _client;

    public HomeController(HttpClient client)
    {
        _client = client;
        _client.BaseAddress = baseUrl;
    }


    public IActionResult Index()
    {
        HomeViewModel homeVM = new();

        HttpResponseMessage responseCategory = _client.GetAsync(_client.BaseAddress + "/Categories/GetAllCategories").Result;
        HttpResponseMessage responseVacancy = _client.GetAsync(_client.BaseAddress + "/Vacancies/GetAllVacancies").Result;
        HttpResponseMessage responseCompany = _client.GetAsync(_client.BaseAddress + "/Companies/GetAllCompanies").Result;
        if (responseCategory.IsSuccessStatusCode && responseCompany.IsSuccessStatusCode && responseVacancy.IsSuccessStatusCode)
        {
            string dataCategory = responseCategory.Content.ReadAsStringAsync().Result;
            string dataVacancy = responseVacancy.Content.ReadAsStringAsync().Result;
            string dataCompany = responseCompany.Content.ReadAsStringAsync().Result;
            homeVM.Categories = JsonConvert.DeserializeObject<List<CategoryVM>>(dataCategory);
            homeVM.Vacancies = JsonConvert.DeserializeObject<List<VacancyVM>>(dataVacancy);
            homeVM.Companies = JsonConvert.DeserializeObject<List<CompanyVM>>(dataCompany);
            return View(homeVM);


        }
        return RedirectToAction("Index", "Error");

    }




}