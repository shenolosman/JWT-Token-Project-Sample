using Microsoft.AspNetCore.Mvc;

namespace JWT.WebApp.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult SignIn()
        {
            return View();
        }

        public IActionResult SignUp()
        {
            throw new NotImplementedException();
        }
    }
}
