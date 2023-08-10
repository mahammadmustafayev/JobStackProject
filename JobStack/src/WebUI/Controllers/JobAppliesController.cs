using JobStack.WebUI.ViewModels.JobApply;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
    public IActionResult SendApply()
    {
        //List<JobApplyPostDto> jobs = new();
        //HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + $"/Vacancies/Details/{id}").Result;
        ////vacancyId = id;
        //ViewBag.VacancyId = id;
        //if (response.IsSuccessStatusCode)
        //{
        //    string data = response.Content.ReadAsStringAsync().Result;
        //    jobs = JsonConvert.DeserializeObject<List<JobApplyPostDto>>(data);
        //}
        //return View(jobs[0]);
        return View();
    }

    //   /JobApplies/Post?VacancyId=2&FirstName=test&LastName=testov&EmailAddress=mmmyev125%40gmail.com&Description=thhtgtegtg

    // CvFileUrl=@testcv.pdf;type=application/pdf

    //  "CvFileUrl":{"ContentDisposition":"form-data; name=\"CvFileUrl\"; filename=\"testcv.pdf\"","ContentType":"application/pdf","Headers":{"Content-Disposition":["form-data; name=\"CvFileUrl\"; filename=\"testcv.pdf\""],"Content-Type":["application/pdf"]},"Length":150465,"Name":"CvFileUrl","FileName":"testcv.pdf"}
    [HttpPost]
    public IActionResult SendApply(int id, JobApplyPostDto jobApply)
    {
        JobApplyPostDto job = new()
        {
            FirstName = jobApply.FirstName,
            LastName = jobApply.LastName,
            EmailAddress = jobApply.EmailAddress,
            Description = jobApply.Description,
            CvFileUrl = jobApply.CvFileUrl,
            VacancyId = id
        };
        //string data = JsonConvert.SerializeObject(job);
        //StringContent content = new(data, Encoding.UTF8, "application/json");   // &CvFileUrl=@{job.CvFileUrl};type=application/pdf
        //HttpResponseMessage response = _client.PostAsync(_client.BaseAddress + $"/JobApplies/Post?VacancyId={job.VacancyId}&FirstName={job.FirstName}&LastName={job.LastName}&EmailAddress={job.EmailAddress}&Description={job.Description}&CvFileUrl:{{\"ContentDisposition\":\"form-data; name=\\\"CvFileUrl\\\"; filename=\\\"{job.CvFileUrl.FileName}\\\"\",\"ContentType\":\"{job.CvFileUrl.ContentType}\",\"Headers\":{{\"Content-Disposition\":[\"form-data; name=\\\"CvFileUrl\\\"; filename=\\\"{job.CvFileUrl.FileName}\\\"\"],\"Content-Type\":[\"application/pdf\"]}},\"Length\":{job.CvFileUrl.Length},\"Name\":\"CvFileUrl\",\"FileName\":\"{job.CvFileUrl.FileName}\"", content).Result;
        //HttpResponseMessage response = _client.PostAsync(_client.BaseAddress + $"/JobApplies/Post?", content).Result;
        //if (response.IsSuccessStatusCode)
        //{
        //    return RedirectToAction(nameof(Index));
        //}
        string root = Path.Combine(Directory.GetParent("src").Parent.ToString(), "WebUI", "wwwroot", "data", "jobapply");

        string filePath = root;
        using (var form = new MultipartFormDataContent())
        {
            form.Add(new StringContent(job.VacancyId.ToString()), "VacancyId");
            form.Add(new StringContent(job.FirstName), "FirstName");
            form.Add(new StringContent(job.LastName), "LastName");
            form.Add(new StringContent(job.EmailAddress), "EmailAddress");
            form.Add(new StringContent(job.Description), "Description");
            //form.Add(new StringContent(job.CvFileUrl.ToString()), "CvFileUrl");

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                //var fileContent = new StreamContent(fileStream);
                //fileContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
                //{
                //    Name = "CvFileUrl",
                //    FileName = Path.GetFileName(filePath)

                //};
                //form.Add(fileContent, "CvFileUrl", Path.GetFileName(filePath));
                job.CvFileUrl.CopyTo(fileStream);
            }
            HttpResponseMessage response = _client.PostAsync(_client.BaseAddress + $"/JobApplies/Post", form).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
        }
        return View();
    }
}
