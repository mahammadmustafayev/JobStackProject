using JobStack.WebUI.DTOs.Candidate;
using JobStack.WebUI.Utilities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using WebUI.Models;


namespace JobStack.WebUI.Controllers;

public class CandidatesController : Controller
{
    Uri baseUrl = new("http://localhost:7264/api");
    private readonly HttpClient _client;
    private readonly IWebHostEnvironment _env;

    public CandidatesController(HttpClient client, IWebHostEnvironment env)
    {
        _client = client;
        _client.BaseAddress = baseUrl;
        _env = env;
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
        var test = JsonConvert.DeserializeObject<string[]>(candidates[0].CandidateSkillName);
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
        List<CandidateEditDto> candidates = new();
        HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + $"/Candidates/Details/{id}").Result;
        if (response.IsSuccessStatusCode)
        {
            string data = response.Content.ReadAsStringAsync().Result;
            candidates = JsonConvert.DeserializeObject<List<CandidateEditDto>>(data);
        }
        TempData["OldImage"] = candidates[0].CandidateProfilImage;
        TempData["OldCV"] = candidates[0].CandidateCV;
        var test = JsonConvert.DeserializeObject<string[]>(candidates[0].CandidateSkillName);
        ViewBag.Countries = CountryAll();
        ViewBag.Cities = CityAll();
        ViewBag.Skills = JsonConvert.DeserializeObject<string[]>(candidates[0].CandidateSkillName);
        return View(candidates[0]);
    }
    [HttpPost]
    public IActionResult Edit(string skills, CandidateEditDto candidateEdit)
    {
        var imagefolderPath = Path.Combine(_env.WebRootPath, "data", "candidate", "images");
        var cvfolderPath = Path.Combine(_env.WebRootPath, "data", "candidate", "resume");
        string imagereturnPath = candidateEdit.CandidateProfileUrl.SaveFile(imagefolderPath);
        string cvreturnPath = candidateEdit.CandidateCVUrl.SaveFile(cvfolderPath);
        CandidateUpdateDto candidateUpdate = new()
        {
            CandidateId = candidateEdit.Id,
            CandidateCV = cvreturnPath,
            CandidateEmail = candidateEdit.CandidateEmail,
            CandidateFirstName = candidateEdit.CandidateFirstName,
            CandidateLastName = candidateEdit.CandidateLastName,
            CandidateProfession = candidateEdit.CandidateProfession,
            CandidateProfilImage = imagereturnPath,
            CandidateSkillName = candidateEdit.CandidateSkillName,
            CityId = candidateEdit.CityId,
            CountryId = candidateEdit.CountryId,
            Description = candidateEdit.Description,
        };
        string data = JsonConvert.SerializeObject(candidateUpdate);
        StringContent content = new(data, Encoding.UTF8, "application/json");
        HttpResponseMessage result = _client.PutAsync(_client.BaseAddress + "/Candidates/Put", content).Result;
        HttpResponseMessage response = result;
        if (response.IsSuccessStatusCode)
        {
            string OldPicture = TempData["OldImage"] as string;
            string OldCV = TempData["OldCV"] as string;

            var fullImagePath = Path.Combine(imagefolderPath, OldPicture);
            var fullCvPath = Path.Combine(cvfolderPath, OldCV);
            if (System.IO.File.Exists(fullCvPath)) System.IO.File.Delete(fullCvPath);
            if (System.IO.File.Exists(fullImagePath)) System.IO.File.Delete(fullImagePath);
            return RedirectToAction(nameof(Details));
        }
        return View(candidateEdit);
    }
}
