using Microsoft.AspNetCore.Mvc;

namespace JobStack.WebUI.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
