﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogSite.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")] //
    [Authorize(Roles = "Admin, Editor")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
