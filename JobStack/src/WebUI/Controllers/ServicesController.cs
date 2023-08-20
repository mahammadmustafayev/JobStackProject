using Microsoft.AspNetCore.Mvc;

namespace JobStack.WebUI.Controllers
{
    public class ServicesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
