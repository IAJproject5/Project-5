using Microsoft.AspNetCore.Mvc;
using Project_5.Data;
using Project_5.Helpers;
using Project_5.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Text.Json;
using System.Collections;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Numerics;

namespace Project_5.Controllers
{
    public class JSPlanModel
    {
        public string name { get; set; }
        public int year { get; set; }
        public string major { get; set; }
        public string studentName { get; set; }
        public string currentSemester { get; set; }
        public List<JSCourse> courses { get; set; }
    }
    public class JSCourse
    {
        public string id { get; set; }
        public string name { get; set; }
        public int credits { get; set; }
        public string term { get; set; }
        public int year { get; set; }
    }

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

    public class CategoryCourses
    {
        public Dictionary<string, string> courses { get; set; }
    }

    public class Category
    {
        public Dictionary<string,string> courses { get; set; }
    }
    [Authorize]
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

		[HttpGet("plan/{planIdInput}")]
		public IActionResult Index(string planIdInput)
		{
			System.Diagnostics.Debug.WriteLine("Request made for plan!");

            int planId = Int32.Parse(planIdInput);
            IajPlan plan = PlanHelper.getPlan(planId);
            // Plan not found and plan not belonging to user both return an empty JSON object.
            if (plan == null)
            {
                return Json(new { });
            }
            string userId = plan.UserId;
            if (userId != User.FindFirstValue(ClaimTypes.NameIdentifier) && !FacultyHelper.isAdviseeAdvisor(User.FindFirstValue(ClaimTypes.NameIdentifier), userId))
            {
                return Json(new { });
            }
            List<IajPlanCourse> courses = PlanHelper.getPlanCourses(planId);
            Dictionary<string, PlanCourse> planCourses = new Dictionary<string, PlanCourse>();
            foreach (var course in courses) 
            {
                if (course.CourseId != "")
                {
                    planCourses.Add(course.CourseId, new PlanCourse
                    {
                        id = course.CourseId,
                        year = course.Year,
                        term = course.Term
                    });
                }
            }
            List<IajPlanSubject> subjects = PlanHelper.getPlanSubjects(planId);
			List<string> subjectNames = new List<string>();
            string major = "";
            string minor = "";
            bool first = true;
            bool firstMinor = true;
            foreach (var subject in subjects)
            {
                if (!subjectNames.Contains(subject.Subject.ToString()))
                {
                    subjectNames.Add(subject.Subject.ToString());
                    if (subject.Type == "Major")
                    {
                        if (first)
                        {
                            first = false;
                            major += subject.Subject;
                        }
                        else
                        {
                            major += ", " + subject.Subject;
                        }
                    }
                    if (subject.Type == "Minor")
                    {
                        if (firstMinor)
                        {
							firstMinor = false;
                            minor += subject.Subject;
                        }
                        else
                        {
                            minor += ", " + subject.Subject;
                        }
                    }
                }
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
                    student = "", //UserManagementHelper.getUserInfo(userId).UserName,
                    catalog = (int)plan.Catalog,
                    courses = planCourses,
                    major = major,
                    minor = minor,
                    majors = subjectNames.ToArray(),
                    currYear = Int32.Parse(DateTime.Today.ToString("yyyy")),
                    currTerm = getCurrentTerm()
                },
                catalog = new
                {
                    courses = catalogCourseArray
                }
			};
            return Json(returnPlan);
		}

		[HttpGet("plan/{planIdInput}/requirements")]
		public IActionResult Requirements(string planIdInput)
		{
			int planId = Int32.Parse(planIdInput);
			IajPlan plan = PlanHelper.getPlan(planId);
            // Plan not found and plan not belonging to user both return an empty JSON object.
            if (plan == null)
            {
                return Json(new { });
            }
            string userId = plan.UserId;
            if (userId != User.FindFirstValue(ClaimTypes.NameIdentifier) && !FacultyHelper.isAdviseeAdvisor(User.FindFirstValue(ClaimTypes.NameIdentifier), userId))
            {
                return Json(new { });
            }
            var requirements = PlanHelper.getPlanRequirements(planId);

			Dictionary<string, Category> theseCategories = new Dictionary<string, Category>();
            foreach (var requirement in requirements)
            {
                if (requirement != null)
                {
                    if (!theseCategories.ContainsKey(requirement.Category))
                    {
						theseCategories.Add(requirement.Category, new Category
                        {
                            courses = new Dictionary<string,string>()
                        });
                    }
					theseCategories[requirement.Category].courses[requirement.CourseId] = requirement.CourseId;
                }
            }
            var returnRequirements = new
            {
				categories = theseCategories
			};
			return Json(returnRequirements);
		}
        [HttpPost("plan/{planIdInput}")]
        public IActionResult Update(string planIdInput, [FromBody] JSPlanModel model)
        {
            int planId = Int32.Parse(planIdInput);
            IajPlan updatePlan = PlanHelper.getPlan(planId);
            // Prevents users from updating plan unless it exists, and the user is the owner or faculty member
            if (updatePlan == null)
            {
                return Json(new { });
            }
            string userId = updatePlan.UserId;
            if (userId != User.FindFirstValue(ClaimTypes.NameIdentifier) && !FacultyHelper.isAdviseeAdvisor(User.FindFirstValue(ClaimTypes.NameIdentifier), userId))
            {
                return Json(new { });
            }
            updatePlan.PlanName = model.name;
            var planCourses = new List<IajPlanCourse>();
            PlanHelper.deletePlanCourses(planId);
            foreach (JSCourse course in model.courses)
            {
                var newCourse = new IajPlanCourse();
                newCourse.PlanId = planId;
                newCourse.CourseId = course.id;
                newCourse.Term = course.term;
                newCourse.Year = course.year;
                planCourses.Add(newCourse);
            }
            PlanHelper.setPlanCourses(planId, planCourses);
            return Json(new { });
        }
	}
}
