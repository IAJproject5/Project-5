using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Project_5.Data;
using Microsoft.AspNetCore.Identity;

namespace Project_5.Controllers
{
	//[Authorize(Roles = "Administrator")]
	public class RoleController : Controller
    {
        private Project_5Context context;

        public RoleController(Project_5Context ctx) 
        {
            this.context = ctx;
        }
        public IActionResult Index()
        {
            var roles = context.Roles.ToList();
            return View(roles);
        }

        public IActionResult Create()
        {
            return View(new IdentityRole());
        }

        [HttpPost]
        public async Task<IActionResult> Create(IdentityRole role)
        {
            await context.AddAsync(role);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
