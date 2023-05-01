using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Project_5.Helpers;

namespace Project_5.Controllers
{
	[Authorize(Roles = "Faculty,Administrator")]
	public class FacultyController : Controller
	{
		private UserManagementHelper helper;
		public FacultyController(UserManagementHelper userManagementHelper)
		{
			this.helper = userManagementHelper;
		}
		public IActionResult Index()
		{
			return View("Views/Faculty/Index.cshtml", UserManagementHelper.getUserList());
		}
		[HttpGet("faculty/{studentId}")]
		public IActionResult Details(string studentId)
		{
			return View("Views/Faculty/Details.cshtml", UserManagementHelper.getUserInfo(studentId));
		}
	}
}
