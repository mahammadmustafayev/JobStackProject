using Microsoft.AspNetCore.Mvc;

namespace JobStack.WebUI.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
