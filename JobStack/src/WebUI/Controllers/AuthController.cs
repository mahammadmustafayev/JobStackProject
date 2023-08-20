using Microsoft.AspNetCore.Mvc;

namespace JobStack.WebUI.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult RegisterCompany()
        {
            return View();
        }
        public IActionResult RegisterCandidate()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
    }
}
