using Project_5.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project_5.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Project_5.Data;
using Project_5.Helpers;

namespace Project_5.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class UserManagementController : Controller
    {
        private UserManagementHelper helper;

        public UserManagementController(UserManagementHelper userManagementHelper)
        {
            this.helper = userManagementHelper;
        }

        // GET: Users
        [HttpGet("UserManagement")]
        public IActionResult Index()
        {
            return View("Views/UserManagement/Index.cshtml", UserManagementHelper.getUserList());
        }
        [HttpGet("UserManagement/{userId}/Delete")]
        public IActionResult Delete(string userId)
        {
            UserManagementHelper.deleteUser(userId);
            return RedirectToAction("Index");
        }
        [HttpGet("UserManagement/{userId}")]
        public IActionResult Index(string userId)
        {
            return View("Views/UserManagement/Details.cshtml", UserManagementHelper.getUserInfo(userId));
        }

        [HttpPost("UserManagement/Update")]
        public IActionResult Update(Project_5User user)
        {
            UserManagementHelper.updateUser(user);
            return RedirectToAction("Index");
        }
        [HttpPost("UserManagement/{userId}/UpdateRoles")]
        public IActionResult UpdateRoles(string userId, [FromForm] List<string> roleSelect)
        {
            UserManagementHelper.setUserRoles(userId, roleSelect);
            return RedirectToAction("Index");
        }
    }
}
