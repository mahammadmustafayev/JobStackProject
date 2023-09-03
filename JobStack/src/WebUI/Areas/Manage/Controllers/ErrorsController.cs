using Microsoft.AspNetCore.Mvc;

namespace JobStack.WebUI.Areas.Manage.Controllers
{
    public class ErrorsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
