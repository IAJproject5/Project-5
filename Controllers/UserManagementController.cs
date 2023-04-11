using Project_5.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project_5.Areas.Identity.Data;

namespace Project_5.Controllers
{
    //[Authorize(Roles = "Admin")]
    public class UserManagementController : Controller
    {
        //private readonly UserManager<AppUser> userManager;

        //public UserManagementController(UserManager<AppUser> usrMgr)
        //{
        //    userManager = usrMgr;
        //}

        public IActionResult Index()
        {
            return View(/*userManager.Users*/);
        }
    }
}
