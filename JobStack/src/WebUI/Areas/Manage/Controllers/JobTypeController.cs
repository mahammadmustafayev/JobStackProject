using JobStack.WebUI.Areas.Manage.ViewModels.JobType;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using WebUI.Models;

namespace JobStack.WebUI.Areas.Manage.Controllers;

[Area("Manage")]
public class JobTypeController : Controller
{
    Uri baseUrl = new("https://localhost:7264/api");
    private readonly HttpClient _client;

    public JobTypeController(HttpClient client)
    {
        _client = client;
        _client.BaseAddress = baseUrl;
    }

    [HttpGet]
    public IActionResult Index()
    {
        List<JobTypeVM> categories = new();
        HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/JobTypes/ManageGetAllTypes").Result;
        if (response.IsSuccessStatusCode)
        {
            string data = response.Content.ReadAsStringAsync().Result;
            categories = JsonConvert.DeserializeObject<List<JobTypeVM>>(data);
        }
        return View(categories);
    }
    [HttpGet]
    public IActionResult Create()
    {

        return View();
    }
    [HttpPost]
    public IActionResult Create(JobTypePostDto jobType)
    {
        string data = JsonConvert.SerializeObject(jobType);
        StringContent content = new(data, Encoding.UTF8, "application/json");
        HttpResponseMessage result = _client.PostAsync(_client.BaseAddress + $"/JobTypes/Add?TypeName={jobType.TypeName}", content).Result;
        HttpResponseMessage response = result;
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction(nameof(Index));
        }
        return View();

    }
    // /JobTypes/Update?JobTypeId=7&TypeName=test12
    [HttpGet]
    public IActionResult Edit(int id)
    {
        List<JobTypeEditDto> jobType = new();
        HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + $"/JobTypes/Details/{id}").Result;
        if (response.IsSuccessStatusCode)
        {
            string data = response.Content.ReadAsStringAsync().Result;
            jobType = JsonConvert.DeserializeObject<List<JobTypeEditDto>>(data);
        }
        return View(jobType[0]);
    }
    [HttpPost]
    public IActionResult Edit(JobTypeEditDto jobType)
    {
        string data = JsonConvert.SerializeObject(jobType);
        StringContent content = new(data, Encoding.UTF8, "application/json");
        HttpResponseMessage result = _client.PutAsync(_client.BaseAddress + $"/JobTypes/Update?JobTypeId={jobType.Id}&TypeName={jobType.TypeName}", content).Result;
        HttpResponseMessage response = result;
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction(nameof(Index));
        }
        return View(jobType);
    }

    public IActionResult Delete(int id)
    {
        string data = id.ToString();
        StringContent content = new(data, Encoding.UTF8, "application/json");
        HttpResponseMessage result = _client.PostAsync(_client.BaseAddress + $"/JobTypes/Delete?id={id}", content).Result;
        HttpResponseMessage response = result;
        //if (response.IsSuccessStatusCode)
        return RedirectToAction(nameof(Index));

    }

    [HttpGet]
    public IActionResult PermaDelete(int id)
    {
        List<JobTypeVM> jobType = new();
        HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + $"/JobTypes/Details/{id}").Result;
        if (response.IsSuccessStatusCode)
        {
            string data = response.Content.ReadAsStringAsync().Result;
            jobType = JsonConvert.DeserializeObject<List<JobTypeVM>>(data);
        }
        return View(jobType[0]);
    }

    // /JobTypes/Delete/6
    [HttpPost, ActionName(nameof(PermaDelete))]
    public IActionResult DeleteConfirmed(int id)
    {
        HttpResponseMessage result = _client.DeleteAsync(_client.BaseAddress + $"/JobTypes/PermaDelete/perma/{id}").Result;
        HttpResponseMessage response = result;
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction(nameof(Index));
        }
        return View();
    }
}
