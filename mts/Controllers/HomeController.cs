using Microsoft.AspNetCore.Mvc;

namespace mts.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
