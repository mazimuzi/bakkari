using Microsoft.AspNetCore.Mvc;

namespace bakkari.Controllers
{
    public class MessagesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
