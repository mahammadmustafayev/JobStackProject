using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebUI.Models;

namespace JobStack.WebUI.Controllers;

public class CandidatesController : Controller
{
    Uri baseUrl = new("http://localhost:7264/api");
    private readonly HttpClient _client;

    public CandidatesController(HttpClient client)
    {
        _client = client;
        _client.BaseAddress = baseUrl;
    }

    public IActionResult Index()
    {
        List<CandidateVM> candidates = new();
        HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Candidates/GetAllCandidates").Result;
        if (response.IsSuccessStatusCode)
        {
            string data = response.Content.ReadAsStringAsync().Result;
            candidates = JsonConvert.DeserializeObject<List<CandidateVM>>(data);
        }
        return View(candidates);
    }
    public IActionResult Details(int id)
    {
        List<CandidateVM> candidates = new();
        HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + $"/Candidates/Details/{id}").Result;
        if (response.IsSuccessStatusCode)
        {
            string data = response.Content.ReadAsStringAsync().Result;
            candidates = JsonConvert.DeserializeObject<List<CandidateVM>>(data);
        }
        ViewBag.Skills = JsonConvert.DeserializeObject<string[]>(candidates[0].CandidateSkillName);
        return View(candidates[0]);
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
        List<CandidateVM> candidates = new();
        HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + $"/Candidates/Details/{id}").Result;
        if (response.IsSuccessStatusCode)
        {
            string data = response.Content.ReadAsStringAsync().Result;
            candidates = JsonConvert.DeserializeObject<List<CandidateVM>>(data);
        }
        ViewBag.Countries = CountryAll();
        ViewBag.Cities = CityAll();
        ViewBag.Skills = JsonConvert.DeserializeObject<string[]>(candidates[0].CandidateSkillName);
        return View(candidates[0]);
    }
    [HttpPost]
    public IActionResult Edit(CandidateVM candidate)
    {
        return View(candidate);
    }
}
