using Microsoft.AspNetCore.Mvc;

namespace BlogSite.Mvc.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
