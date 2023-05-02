using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project_5.Areas.Identity.Data;
using Project_5.Models;
using System.Diagnostics;

namespace Project_5.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [Authorize]
        public IActionResult Index()
        {
            // Handle redirects to proper pages for Administrators and Faculty who are not also students.
            if (!User.IsInRole("Student"))
            {
				if (User.IsInRole("Administrator")) return RedirectToAction("Index", "UserManagement");
				else if (User.IsInRole("Faculty")) return RedirectToAction("Index", "Faculty");
			}
            return View();
		}

        [Authorize]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
