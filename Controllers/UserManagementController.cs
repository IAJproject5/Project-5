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
    //[Authorize(Roles = "Admin")]
    public class UserManagementController : Controller
    {
        //private readonly UserManager<Project_5User> userManager;

        private UserManagementHelper helper;

        /*public UserManagementController(UserManager<Project_5User> usrMgr)
        {
            userManager = usrMgr;
        }*/

        public UserManagementController(UserManagementHelper userManagementHelper)
        {
            this.helper = userManagementHelper;
        }

        // GET: Users
        [HttpGet]
        public IActionResult Index()
        {
            return View("Views/UserManagement/Index.cshtml", UserManagementHelper.getUserList());
        }

        [HttpGet("UserManagement/{userId}")]
        public IActionResult Index(string userId)
        {
            return View("Views/UserManagement/Details.cshtml", UserManagementHelper.getUserInfo(userId));
        }

        [HttpPost("UserManagement/Update")]
        public IActionResult Update(string userId)
        {
            return View("Views/UserManagement/Update.cshtml");
        }
        [HttpPost]
        public IActionResult Create(Project_5User user)
        {
            return View(user);
        }
        [HttpGet("UserManagement/Create")]
        public IActionResult Create()
        {
            return View("Views/UserManagement/Create.cshtml");
        }

        /*[HttpGet("id")]
        public async Task<IActionResult> Index(int id)
        {
            var user = await context.Users.FindAsync(id);
            var roles = context.UserRoles.Where(b => b.UserId.Equals(user.Id)).ToList();
            return Json(roles);
        }
        public static List<IdentityRole> ListRoles(string userId)
        {
            var roles = context.UserRoles.Where(b => b.UserId.Equals(userId)).ToList();
            List<IdentityRole> roleNames = new List<IdentityRole>();
            foreach (IdentityUserRole<string> roleToUser in roles)
            {
                roleNames.Add(context.Roles.Where(b => b.Id.Equals(roleToUser.RoleId)).FirstOrDefault());
            }
            return roleNames;
        }*/
    }
}
