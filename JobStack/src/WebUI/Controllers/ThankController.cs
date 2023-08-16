using Microsoft.AspNetCore.Mvc;

namespace JobStack.WebUI.Controllers
{
    public class ThankController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
