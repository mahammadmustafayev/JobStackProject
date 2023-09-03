using Microsoft.AspNetCore.Mvc;

namespace JobStack.WebUI.Areas.Manage.Controllers;

[Area("Manage")]

public class DashboardController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
