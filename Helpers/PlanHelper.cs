using Microsoft.AspNetCore.Identity;
using Project_5.Data;
using Project_5.Models;
using System.Data;

namespace Project_5.Helpers
{
	public class PlanHelper
	{
		private static Project5Context context = new Project5Context();

		public PlanHelper()
		{
			context = new Project5Context();
		}
		public PlanHelper(Project5Context ctx)
		{
			context = new Project5Context();
		}
		public static List<IajPlan> getUserPlans(string userId)
		{
			var plans = context.IajPlans.Where(b => b.UserId.Equals(userId)).ToList();
			return plans;
		}
		public static IajPlan getPlan(int planId)
		{
			var plan = context.IajPlans.Where(b => b.PlanId.Equals(planId)).FirstOrDefault();
			return plan;
		}
		public static List<IajPlanCourse> getPlanCourses(int planId)
		{
			var planCourses = context.IajPlanCourses.Where(b => b.PlanId.Equals(planId)).ToList();
			/*var courses = new List<IajCourse>();
			foreach (IajPlanCourse planCoursePair in planCourses)
			{
				courses.Add(context.IajCourses.Where(b => b.CourseId.Equals(planCoursePair.CourseId)).FirstOrDefault());
			}*/
			return planCourses;
		}
		public static List<IajSubject> getPlanSubjects(int planId)
		{
			var planSubjects = context.IajPlanSubjects.Where(b => b.PlanId.Equals(planId.ToString())).ToList();
			List<IajSubject> subjects = new List<IajSubject>();
			foreach (IajPlanSubject planSubjectPair in planSubjects)
			{
				subjects.Add(context.IajSubjects.Where(b => b.Subject.Equals(planSubjectPair.Subject)).FirstOrDefault());
			}
			return subjects;
		}
		public static string? getPlanUserId(int planId)
		{
			var plan = context.IajPlans.Where(b => b.PlanId.Equals(planId)).FirstOrDefault();
			return plan.UserId;
		}

		public static List<IajCourse> getCatalogCourses(decimal? year)
		{
			var catalogCourses = context.IajRequirements.Where(b => b.Year.Equals(year)).ToList();
			var courses = new List<IajCourse>();
			foreach (IajRequirement catalogCoursePair in catalogCourses)
			{
				courses.Add(context.IajCourses.Where(b => b.CourseId.Equals(catalogCoursePair.CourseId)).FirstOrDefault());
			}
			return courses;
		}

		public static List<IajRequirement> getPlanRequirements(int planId)
		{
			var plan = getPlan(planId);
			var planSubjects = context.IajPlanSubjects.Where(b => b.PlanId.Equals(planId)).ToList();
			var requirements = new List<IajRequirement>();
			foreach (var planSubject in planSubjects)
			{
				requirements = requirements.Concat(context.IajRequirements.Where(b => ( b.Subject.Equals(planSubject.Subject) && b.Year.Equals(plan.Catalog)) )).ToList();
			}
			return requirements;
		}
	}
}
