using Microsoft.AspNetCore.Mvc;
using Project_5.Data;

namespace Project_5.Controllers
{
    public class Course
    {
        public string Id { get; set; }
        public int year { get; set; }
        public string term { get; set; }
    }

    public class Major
    {
        public string name { get; set; }
    }
    
    public class Plan
    {
        public string name { get; set; }
        public string planId { get; set; }
        public string student { get; set; }
        public int catalog { get; set; }
        public IList<Course> courses { get; set; }
        public string major { get; set; }
        public IList<Major> majors { get; set; }
        public int currTerm { get; set; }
    }
    
    public class PlanController : Controller
    {
        private string getCurrentTerm()
        {
            int month = DateTime.Now.Month;
            if (month > 5)
            {
                return "Summer";
            }
            else if (month > 7)
            {
                return "Fall";
            }
            else
            {
                return "Spring";
            }
        }

        private Project_5Context context;
        public PlanController(Project_5Context ctx) 
        {
            context = ctx;
        }

        [HttpGet("id")]
        public IActionResult Index(string id)
        {

            return View();
        }
    }
}
