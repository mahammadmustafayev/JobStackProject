using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using WebUI.Models;

namespace JobStack.WebUI.Areas.Manage.Controllers;

[Area("Manage")]
public class CandidateController : Controller
{
    Uri baseUrl = new("http://localhost:7264/api");
    private readonly HttpClient _client;

    public CandidateController(HttpClient client)
    {
        _client = client;
        _client.BaseAddress = baseUrl;
    }
    public IActionResult Index()
    {
        List<CandidateVM> candidates = new();
        HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Candidates/ManageGetAllCandidates").Result;
        if (response.IsSuccessStatusCode)
        {
            string data = response.Content.ReadAsStringAsync().Result;
            candidates = JsonConvert.DeserializeObject<List<CandidateVM>>(data);
        }
        return View(candidates);
    }
    public IActionResult Delete(int id)
    {
        string data = id.ToString();
        StringContent content = new(data, Encoding.UTF8, "application/json");
        HttpResponseMessage result = _client.PostAsync(_client.BaseAddress + $"/Candidates/Delete?id={id}", content).Result;
        return RedirectToAction(nameof(Index));
    }
    public IActionResult PermaDelete(int id)
    {
        string data = id.ToString();
        StringContent content = new(data, Encoding.UTF8, "application/json");
        HttpResponseMessage result = _client.PostAsync(_client.BaseAddress + $"/Candidates/PermaDelete?id={id}", content).Result;
        return RedirectToAction(nameof(Index));
    }
}
