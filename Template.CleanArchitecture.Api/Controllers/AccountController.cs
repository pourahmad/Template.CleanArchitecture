using Microsoft.AspNetCore.Mvc;

namespace Template.CleanArchitecture.Api.Controllers
{
    public class AccountController : Controller
    {
        public AccountController()
        {
                
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
