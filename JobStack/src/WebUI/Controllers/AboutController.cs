using Microsoft.AspNetCore.Mvc;

namespace JobStack.WebUI.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
