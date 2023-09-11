using JobStack.WebUI.DTOs.JobApply;
using JobStack.WebUI.Utilities;
using JobStack.WebUI.ViewModels.JobApply;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using WebUI.Models;

namespace JobStack.WebUI.Controllers;

public class JobAppliesController : Controller
{
    Uri baseUrl = new("http://localhost:7264/api");
    private readonly HttpClient _client;
    private readonly IWebHostEnvironment _env;

    public JobAppliesController(HttpClient client, IWebHostEnvironment env)
    {
        _client = client;
        _client.BaseAddress = baseUrl;
        _env = env;
    }

    public IActionResult Index(int id)
    {
        ViewBag.DetailsId = id;
        List<JobApplyVM> jobApplies = new();
        HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + $"/JobApplies/GetAllJobAppliesVacancy/{id}").Result;
        if (response.IsSuccessStatusCode)
        {
            string data = response.Content.ReadAsStringAsync().Result;
            jobApplies = JsonConvert.DeserializeObject<List<JobApplyVM>>(data);
            return View(jobApplies);
        }
        return RedirectToAction("Index", "Error");
    }
    public IActionResult Details(int id)
    {
        List<JobApplyVM> jobs = new();
        HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + $"/JobApplies/Details/{id}").Result;
        if (response.IsSuccessStatusCode)
        {
            string data = response.Content.ReadAsStringAsync().Result;
            jobs = JsonConvert.DeserializeObject<List<JobApplyVM>>(data);
            return View(jobs[0]);
        }
        return RedirectToAction("Index", "Error");
    }



    [HttpGet]
    public IActionResult SendApply()
    {

        return View();
    }


    [HttpPost]
    public IActionResult SendApply(int id, JobApplyPostDto jobApply)
    {
        var folderPath = Path.Combine(_env.WebRootPath, "data", "jobapply");
        string returnPath = jobApply.CvFileUrl.SaveFile(folderPath);
        JobApplyDto job = new()
        {
            FirstName = jobApply.FirstName,
            LastName = jobApply.LastName,
            EmailAddress = jobApply.EmailAddress,
            Description = jobApply.Description,
            CvFileUrl = returnPath,
            VacancyId = id
        };
        string data = JsonConvert.SerializeObject(job);
        StringContent content = new(data, Encoding.UTF8, "application/json");
        HttpResponseMessage response = _client.PostAsync(_client.BaseAddress + "/JobApplies/Post", content).Result;
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index", "Thank");
        }
        return RedirectToAction("Index", "Error");
    }
}
