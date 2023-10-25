using Microsoft.AspNetCore.Mvc;

namespace Todo.API.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
