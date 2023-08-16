using Microsoft.AspNetCore.Mvc;

namespace JobStack.WebUI.Areas.Manage.Controllers;

public class DashboardController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
