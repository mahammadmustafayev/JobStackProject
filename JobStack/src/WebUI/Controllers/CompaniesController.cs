using JobStack.WebUI.DTOs.Company;
using JobStack.WebUI.Utilities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using WebUI.Models;

namespace JobStack.WebUI.Controllers;

public class CompaniesController : Controller
{
    Uri baseUrl = new("https://localhost:7264/api");
    private readonly HttpClient _client;
    private readonly IWebHostEnvironment _env;

    public CompaniesController(HttpClient client, IWebHostEnvironment env)
    {
        _client = client;
        _client.BaseAddress = baseUrl;
        _env = env;
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
    private List<CountryVM> CountryAll()
    {
        List<CountryVM> countries = new();
        HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Countries/GetAllCountries").Result;
        if (response.IsSuccessStatusCode)
        {
            string data = response.Content.ReadAsStringAsync().Result;
            countries = JsonConvert.DeserializeObject<List<CountryVM>>(data);
        }
        return countries;
    }
    private List<CityVM> CityAll()
    {
        List<CityVM> cities = new();
        HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Cities/GetAllCities").Result;
        if (response.IsSuccessStatusCode)
        {
            string data = response.Content.ReadAsStringAsync().Result;
            cities = JsonConvert.DeserializeObject<List<CityVM>>(data);
        }
        return cities;
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        List<CompanyEditDto> company = new();
        HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + $"/Companies/Details/{id}").Result;
        if (response.IsSuccessStatusCode)
        {
            string data = response.Content.ReadAsStringAsync().Result;
            company = JsonConvert.DeserializeObject<List<CompanyEditDto>>(data);
        }
        TempData["Id"] = id;
        TempData["OldImage"] = company[0].CompanyLogo;
        ViewBag.Countries = CountryAll();
        ViewBag.Cities = CityAll();
        ViewBag.CompanyId = id;
        return View(company[0]);
    }
    [HttpPost]
    public IActionResult Edit(CompanyEditDto companyEdit)
    {
        var imagefolderPath = Path.Combine(_env.WebRootPath, "data", "company");
        string imagereturnPath = companyEdit.CompanyUrl.SaveFile(imagefolderPath);
        CompanyUpdateDto companyUpdate = new()
        {
            CompanyId = Convert.ToInt32(TempData["Id"]),
            CityId = companyEdit.CityId,
            CompanyLogo = imagereturnPath,
            CompanyEmail = companyEdit.CompanyEmail,
            CompanyName = companyEdit.CompanyName,
            CompanySite = companyEdit.CompanySite,
            CountryId = companyEdit.CountryId,
            Description = companyEdit.Description,
            Founded = companyEdit.Founded,
            NumberOfEmployees = companyEdit.NumberOfEmployees
        };
        string data = JsonConvert.SerializeObject(companyUpdate);
        StringContent content = new(data, Encoding.UTF8, "application/json");
        HttpResponseMessage result = _client.PutAsync(_client.BaseAddress + "/Companies/Put", content).Result;
        HttpResponseMessage response = result;
        if (response.IsSuccessStatusCode)
        {
            string OldPicture = TempData["OldImage"] as string;
            var fullImagePath = Path.Combine(imagefolderPath, OldPicture);
            if (System.IO.File.Exists(fullImagePath)) System.IO.File.Delete(fullImagePath);
            return RedirectToAction(nameof(Index));
        }
        return View(companyEdit);
    }
    public IActionResult Delete(int id)
    {
        string data = id.ToString();
        StringContent content = new(data, Encoding.UTF8, "application/json");
        HttpResponseMessage result = _client.PostAsync(_client.BaseAddress + $"/Companies/Delete?id={id}", content).Result;
        return RedirectToAction(nameof(Index));
    }
}
