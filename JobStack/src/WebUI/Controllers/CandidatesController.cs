using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebUI.Models;

namespace JobStack.WebUI.Controllers;

public class CandidatesController : Controller
{
    Uri baseUrl = new("https://localhost:7264/api");
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
        return View(candidates[0]);
    }
}
