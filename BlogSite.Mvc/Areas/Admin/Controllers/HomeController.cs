using Microsoft.AspNetCore.Mvc;

namespace BlogSite.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")] //
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
