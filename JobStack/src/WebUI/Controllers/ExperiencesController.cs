using JobStack.WebUI.DTOs.Experince;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using WebUI.Models;

namespace JobStack.WebUI.Controllers;

public class ExperiencesController : Controller
{
    Uri baseUrl = new("https://localhost:7264/api");
    private readonly HttpClient _client;

    public ExperiencesController(HttpClient client)
    {
        _client = client;
        _client.BaseAddress = baseUrl;
    }

    [HttpGet]
    public IActionResult Index()
    {
        List<ExperienceVM> experiences = new();
        HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Experiences/GetAllExperinces").Result;
        if (response.IsSuccessStatusCode)
        {
            string data = response.Content.ReadAsStringAsync().Result;
            experiences = JsonConvert.DeserializeObject<List<ExperienceVM>>(data);
        }
        return View(experiences);
    }
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Create(int id, ExperienceVM experiencepost)
    {
        ExperienceVM experience = new()
        {
            CandidateId = id,
            ExperienceName = experiencepost.ExperienceName,
            ExperienceDescription = experiencepost.ExperienceDescription,
            ExperienceEndYear = experiencepost.ExperienceEndYear,
            ExperienceStartYear = experiencepost.ExperienceStartYear
        };
        string data = JsonConvert.SerializeObject(experience);
        StringContent content = new(data, Encoding.UTF8, "application/json");
        //HttpResponseMessage result = _client.PostAsync(_client.BaseAddress + $"/Experiences/Post?CandidateId={experience.CandidateId}&ExperienceName={experience.ExperienceName}&ExperienceDescription={experience.ExperienceDescription}&ExperienceStartYear={experience.ExperienceStartYear}&ExperienceEndYear={experience.ExperienceEndYear}", content).Result;
        HttpResponseMessage result = _client.PostAsync(_client.BaseAddress + "/Experiences/Post", content).Result;
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
        ViewBag.ExperienceId = id;
        List<ExperienceVM> experiences = new();
        HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + $"/Experiences/Details/{id}").Result;
        if (response.IsSuccessStatusCode)
        {
            string data = response.Content.ReadAsStringAsync().Result;
            experiences = JsonConvert.DeserializeObject<List<ExperienceVM>>(data);
        }
        return View(experiences[0]);
    }
    [HttpPost]
    public IActionResult Edit(ExperinceEditDto experience)
    {
        string data = JsonConvert.SerializeObject(experience);
        StringContent content = new(data, Encoding.UTF8, "application/json");
        HttpResponseMessage result = _client.PutAsync(_client.BaseAddress + $"/Experiences/Put?ExperienceId={experience.Id}&ExperienceName={experience.ExperienceName}&ExperienceDescription={experience.ExperienceDescription}&ExperienceStartYear={experience.ExperienceStartYear}&ExperienceEndYear={experience.ExperienceEndYear}", content).Result;
        HttpResponseMessage response = result;
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction(nameof(Index));
        }
        return View(experience);
    }
    public IActionResult Delete(int id)
    {
        string data = id.ToString();
        StringContent content = new(data, Encoding.UTF8, "application/json");
        HttpResponseMessage result = _client.PostAsync(_client.BaseAddress + $"/Experiences/Delete?id={id}", content).Result;
        HttpResponseMessage response = result;
        //if (response.IsSuccessStatusCode)
        return RedirectToAction(nameof(Index));

    }
}
