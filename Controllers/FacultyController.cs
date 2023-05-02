using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Project_5.Helpers;
using System.Security.Claims;

namespace Project_5.Controllers
{
	[Authorize(Roles = "Faculty,Administrator")]
	public class FacultyController : Controller
	{
		private UserManagementHelper helper;
		private FacultyHelper facultyHelper;
		public FacultyController(UserManagementHelper userManagementHelper, FacultyHelper facultyHelper)
		{
			// Instantiates helpers so they can be used.
            this.helper = userManagementHelper;
			this.facultyHelper = facultyHelper;
		}
		public IActionResult Index()
		{
			// If a user is an administrator but not a faculty member, send them to the User Management page.
            if (!User.IsInRole("Faculty"))
            {
                if (User.IsInRole("Administrator")) return RedirectToAction("Index", "UserManagement");
            }
            return View("Views/Faculty/Index.cshtml", FacultyHelper.getAdviseeList(User.FindFirstValue(ClaimTypes.NameIdentifier)));
		}
		// This allows faculty to view a student's plans.
		[HttpGet("faculty/{studentId}")]
		public IActionResult Details(string studentId)
		{
            if (!User.IsInRole("Faculty"))
            {
                if (User.IsInRole("Administrator")) return RedirectToAction("Index", "UserManagement");
            }
            return View("Views/Faculty/Details.cshtml", UserManagementHelper.getUserInfo(studentId));
		}
	}
}
