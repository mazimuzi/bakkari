using Microsoft.AspNetCore.Mvc;

namespace bakkari.Controllers
{
    public class UsersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
