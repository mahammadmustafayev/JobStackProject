using JobStack.WebUI.ViewModels.JobApply;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using WebUI.Models;

namespace JobStack.WebUI.Controllers;

public class JobAppliesController : Controller
{
    Uri baseUrl = new("https://localhost:7264/api");
    private readonly HttpClient _client;

    public JobAppliesController(HttpClient client)
    {
        _client = client;
        _client.BaseAddress = baseUrl;
    }

    public IActionResult Index(int id)
    {
        List<JobApplyVM> jobApplies = new();
        HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + $"/JobApplies/GetAllJobAppliesVacancy/{id}").Result;
        if (response.IsSuccessStatusCode)
        {
            string data = response.Content.ReadAsStringAsync().Result;
            jobApplies = JsonConvert.DeserializeObject<List<JobApplyVM>>(data);
        }
        return View(jobApplies);
    }
    public IActionResult Details(int id)
    {
        List<JobApplyVM> jobs = new();
        HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + $"/JobApplies/Details/{id}").Result;
        if (response.IsSuccessStatusCode)
        {
            string data = response.Content.ReadAsStringAsync().Result;
            jobs = JsonConvert.DeserializeObject<List<JobApplyVM>>(data);
        }
        return View(jobs[0]);
    }

    //  /JobApplies/Post?VacancyId=5&FirstName=dds&LastName=dddd&EmailAddress=mahammad%40gmail.com&Description=saddd'

    int vacancyId;

    [HttpGet]
    public IActionResult SendApply(int id)
    {
        List<JobApplyPostDto> jobs = new();
        HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + $"/Vacancies/Details/{id}").Result;
        //vacancyId = id;
        ViewBag.VacancyId = id;
        if (response.IsSuccessStatusCode)
        {
            string data = response.Content.ReadAsStringAsync().Result;
            jobs = JsonConvert.DeserializeObject<List<JobApplyPostDto>>(data);
        }
        return View(jobs[0]);
        //return View();
    }
    [HttpPost]
    public IActionResult SendApply(JobApplyPostDto jobApply)
    {
        JobApplyPostDto job = new()
        {
            FirstName = jobApply.FirstName,
            LastName = jobApply.LastName,
            Description = jobApply.Description,
            CvFileUrl = jobApply.CvFileUrl,
            VacancyId = ViewBag.VacancyId
        };
        string data = JsonConvert.SerializeObject(job);
        StringContent content = new(data, Encoding.UTF8, "application/json");
        HttpResponseMessage response = _client.PostAsync(_client.BaseAddress + "/JobApplies/Post", content).Result;
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction(nameof(Index));
        }
        return View();
    }
}
