using Microsoft.AspNetCore.Mvc;
using Project_5.Data;
using Project_5.Helpers;
using Project_5.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Text.Json;
using System.Collections;

public class PlanCombined
{
    public string? name;
    public int? planID;
    public string? student;
    public int? catalog;
    public List<string>? courses;
    public string? major;
	public List<string>? majors;
    public int? currYear;
    public string? currTerm;

    public PlanCombined()
    {

    }
}

namespace Project_5.Controllers
{
    public class Course
    {
        public string? id { get; set; }
        public string? name { get; set; }
        public string? description { get; set; }
        public int? credits { get; set; }
    }

    public class Major
    {
        public string name { get; set; }
    }
    
    public class PlanCourse
    {
        public string? id { get; set; }
        public int? year { get; set; }
        public string? term { get; set; }
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

        /*[HttpGet("id")]
        public IActionResult Index(string id)
        {

            return View();
        }*/
		[HttpGet("plan/{planIdInput}")]
		public IActionResult Index(string planIdInput)
		{
			System.Diagnostics.Debug.WriteLine("Request made for plan!");

            int planId = Int32.Parse(planIdInput);
            IajPlan plan = PlanHelper.getPlan(planId);
            string userId = plan.UserId;
            List<IajPlanCourse> courses = PlanHelper.getPlanCourses(planId);
            Dictionary<string, PlanCourse> planCourses = new Dictionary<string, PlanCourse>();
            foreach (var course in courses) 
            {
				planCourses.Add(course.CourseId, new PlanCourse
                {
                    id = course.CourseId,
                    year = course.Year,
                    term = course.Term
                });
            }
            //if (planCourses.Count == 0) return View();
            List<IajSubject> subjects = PlanHelper.getPlanSubjects(planId);
			List<string> subjectNames = new List<string>();
            foreach (var subject in subjects)
            {
                subjectNames.Add(subject.Subject);
            }
            List<IajCourse> catalogCourses = PlanHelper.getCatalogCourses(plan.Catalog);
            Dictionary<string, Course> catalogCourseArray = new Dictionary<string, Course>();

			foreach (var course in catalogCourses)
			{
				catalogCourseArray.Add(course.CourseId, new Course
                {
                    id = course.CourseId,
                    name = course.Name,
                    description = course.Description,
                    credits = course.Credits
                });
			}
			DateTime now = DateTime.Today;
            var returnPlan = new
            {
                plan = new
                {
                    name = plan.PlanName,
                    planID = planId,
                    student = "",// UserManagementHelper.getUserInfo(plan.UserId).UserName,
                    catalog = (int)plan.Catalog,
                    courses = planCourses,
                    major = "",
                    majors = subjectNames.ToArray(),
                    currYear = Int32.Parse(DateTime.Today.ToString("yyyy")),
                    currTerm = getCurrentTerm()
                },
                catalog = new
                {
                    courses = catalogCourseArray
                }
			};
            /*returnPlan.name = userId;
		    returnPlan.planID = planId;
		    //returnPlan.student = UserManagementHelper.getUserInfo(plan.UserId).UserName;
		    returnPlan.catalog = (int)plan.Catalog;
		    returnPlan.courses = courseIDs;
		    returnPlan.major = "";
		    returnPlan.majors = subjectNames;
		    returnPlan.currYear = Int32.Parse(DateTime.Today.ToString("yyyy"));
            returnPlan.currTerm = getCurrentTerm();*/
            return Json(returnPlan);
		}
	}
}
