using JobStack.WebUI.DTOs.AuthDTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using WebUI.Models;

namespace JobStack.WebUI.Controllers;

public class AuthController : Controller
{
    Uri baseUrl = new("http://localhost:7264/api");
    private readonly HttpClient _client;

    public AuthController(HttpClient client)
    {
        _client = client;
        _client.BaseAddress = baseUrl;
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
    public IActionResult Login()
    {

        return View();
    }
    [HttpPost]
    public IActionResult Login(LoginDto login)
    {
        LoginDto loginDto = new()
        {
            Email = login.Email,
            Password = login.Password,
            RememberMe = false
        };
        string data = JsonConvert.SerializeObject(loginDto);
        StringContent content = new(data, Encoding.UTF8, "application/json");
        HttpResponseMessage result = _client.PostAsync(_client.BaseAddress + "/Author/Login", content).Result;
        HttpResponseMessage response = result;
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index", "Home");
        }
        return View();
    }
    [HttpGet]
    public IActionResult RegisterCompany()
    {
        ViewBag.Countries = CountryAll();
        ViewBag.Cities = CityAll();
        return View();
    }
    [HttpPost]
    public IActionResult RegisterCompany(RegisterCompanyDto registerCompany)
    {
        string data = JsonConvert.SerializeObject(registerCompany);
        StringContent content = new(data, Encoding.UTF8, "application/json");
        HttpResponseMessage result = _client.PostAsync(_client.BaseAddress + "/Author/RegisterCompany", content).Result;
        HttpResponseMessage response = result;
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index", "Companies");
        }
        return View();
    }
    [HttpGet]
    public IActionResult RegisterCandidate()
    {
        ViewBag.Countries = CountryAll();
        ViewBag.Cities = CityAll();
        return View();
    }
    [HttpPost]
    public IActionResult RegisterCandidate(RegiserCandidateDto regiserCandidate)
    {
        string data = JsonConvert.SerializeObject(regiserCandidate);
        StringContent content = new(data, Encoding.UTF8, "application/json");
        HttpResponseMessage result = _client.PostAsync(_client.BaseAddress + "/Author/RegisterCandidate", content).Result;
        HttpResponseMessage response = result;
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index", "Candidates");
        }
        return View();
    }
    public IActionResult Register()
    {
        return View();
    }
    public IActionResult SignOut()
    {
        return View();
    }
}
