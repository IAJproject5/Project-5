using System.Collections;
using Microsoft.EntityFrameworkCore;
using Project_5.Models;

public class GetQuery
{
	protected void IConfiguration(DbContextOptionsBuilder optionsBuilder)
	{
		optionsBuilder.UseMySql("name=ConnectionStrings:Project_5ContextConnection", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.27-mariadb"));
	}
	public ArrayList planIds(string uID)
	{
		using (var context = new Project5Context())
		{
			var ids = from a in context.IajPlans
					  where a.UserId == uID
					  select a.PlanId;
			int i = 0;
			var varlist = new ArrayList();
			foreach (int var in ids)
			{
				varlist.Add(var);
				i += 1;
			}
			return varlist;
		}
	}
	public ArrayList planNames(string uID)
	{
		using (var context = new Project5Context())
		{
			var names = from a in context.IajPlans
						where a.UserId == uID
						select a.PlanName;
			int i = 0;
			var varlist = new ArrayList();
			foreach (string var in names)
			{
				varlist.Add(var);
				i += 1;
			}
			return varlist;
		}
	}
	//May need to be changed to only return 1.
	public string planName(int pID)
	{
		using (var context = new Project5Context())
		{
			var name = from a in context.IajPlans
					   where a.PlanId == pID
					   select a.PlanName;
			foreach (string var in name)
			{
				return var;
			}
			return "";
		}
	}
	public int planID(string pName)
	{
		using (var context = new Project5Context())
		{
			var name = from a in context.IajPlans
					   where a.PlanName == pName
					   select a.PlanId;
			foreach (int var in name)
			{
				return var;
			}
			return 0;
		}
	}
	public string defaultPlan(string uID)
	{
		using (var context = new Project5Context())
		{
			var name = from a in context.IajPlans
					   where (a.UserId == uID && a.DefaultPlan == "true")
					   select a.PlanName;
			int i = 0;
			var varlist = new ArrayList();
			foreach (string var in name)
			{
				return var;
			}
			return "";
		}
	}
	public int catalogYear(int pID)
	{
		using (var context = new Project5Context())
		{
			var years = from a in context.IajPlans
						where a.PlanId == pID
						select a.Catalog;
			foreach (int year in years)
			{
				return year;
			}
			return 0;
		}
	}
	public ArrayList mySubjects(int pID)
	{
		using (var context = new Project5Context())
		{
			var subjects = from a in context.IajPlanSubjects
						   where a.PlanId == pID
						   select a.Subject;
			int i = 0;
			var varlist = new ArrayList();
			foreach (string subject in subjects)
			{
				varlist.Add(subject);
				i += 1;
			}
			varlist.TrimToSize();
			return varlist;
		}
	}
	public ArrayList subjectTypes(int pID)
	{
		using (var context = new Project5Context())
		{
			var types = from a in context.IajPlanSubjects
						where a.PlanId == pID
						select a.Type;
			int i = 0;
			var varlist = new ArrayList();
			foreach (string type in types)
			{
				varlist.Add(type);
				i += 1;
			}
			return varlist;
		}
	}

	public ArrayList planCourses(int pID)
	{
		using (var context = new Project5Context())
		{
			var courses = from a in context.IajPlanCourses
						  where a.PlanId == pID
						  select a.CourseId;
			int i = 0;
			var varlist = new ArrayList();
			foreach (string course in courses)
			{
				varlist.Add(course);
				i += 1;
			}
			return varlist;
		}
	}

	public ArrayList planCourseTerms(int pID)
	{
		using (var context = new Project5Context())
		{
			var terms = from a in context.IajPlanCourses
						where a.PlanId == pID
						select a.Term;
			int i = 0;
			var varlist = new ArrayList();
			foreach (string term in terms)
			{
				varlist.Add(term);
				i += 1;
			}
			return varlist;
		}
	}

	public ArrayList planCourseYears(int pID)
	{
		using (var context = new Project5Context())
		{
			var years = from a in context.IajPlanCourses
						where a.PlanId == pID
						select a.Year;
			int i = 0;
			var varlist = new ArrayList();
			foreach (int year in years)
			{
				varlist.Add(year);
				i += 1;
			}
			return varlist;
		}
	}

	public ArrayList requirements(int year, ArrayList subjects, ArrayList subjectTypes)
	{

		int i = 0;
		var varlist = new ArrayList();
		for (int j = 0; j < subjects.Capacity; j++)
		{
			using (var context = new Project5Context())
			{
				var requirements = from a in context.IajRequirements
								   where a.Year == year
								   where a.Subject == subjects[j]
								   where a.Type == subjectTypes[j]
								   select a.CourseId;
				foreach (string requirement in requirements)
				{
					varlist.Add(requirement);
					i += 1;
				}
			}
		}
		return varlist;
	}

	public ArrayList requirementCategories(int year, ArrayList subjects, ArrayList subjectTypes)
	{

		int i = 0;
		var varlist = new ArrayList();
		for (int j = 0; j < subjects.Capacity; j++)
		{
			using (var context = new Project5Context())
			{
				var categories = from a in context.IajRequirements
								 where a.Year == year
								 where a.Subject == subjects[j]
								 where a.Type == subjectTypes[j]
								 select a.Category;
				foreach (string category in categories)
				{
					varlist.Add(category);
					i += 1;
				}
			}
		}
		return varlist;
	}
	public ArrayList subjects()
	{
		using (var context = new Project5Context())
		{
			var subjects = from a in context.IajSubjects
						   select a.Subject;
			var types = from a in context.IajSubjects
						select a.Type;
			int i = 0;
			var varlist = new ArrayList();
			var typesList = new ArrayList();
			foreach (var type in types)
			{
				typesList.Add(type);
			}
			foreach (string subject in subjects)
			{
				varlist.Add(subject + " " + typesList[i]);
				i += 1;
			}

			varlist.TrimToSize();
			return varlist;
		}
	}
	//Setters
	public void newUserDefaultPlan(string uID)
	{
		using (var context = new Project5Context())
		{
			var name = new IajPlan { UserId = uID, PlanName = "My Plan", Catalog = 2023, DefaultPlan = "true" };
			context.IajPlans.Add(name);
			context.SaveChanges();
		}
	}
	public void createNewPlan(string userID, string planName, int planYear)
	{
		using (var context = new Project5Context())
		{
			var add = new IajPlan { UserId = userID, PlanName = planName, Catalog = planYear, DefaultPlan = "false" };
			context.IajPlans.Add(add);
			context.SaveChanges();
		}
	}
	public void deletePlan(int planID)
	{
		using (var context = new Project5Context())
		{
			var remove = context.IajPlans.Where(d => d.PlanId == planID).First();
			context.IajPlans.Remove(remove);
			context.SaveChanges();
		}
	}
	public void addSubjectToPlan(int planID, string subject, string type)
	{
		using (var context = new Project5Context())
		{
			var add = new IajPlanSubject { PlanId = planID, Subject = subject, Type = type };
			context.IajPlanSubjects.Add(add);
			context.SaveChanges();
		}
	}
	public void addCourse(int planID, string courseID, int year, string term)
	{
		using (var context = new Project5Context())
		{
			var add = new IajPlanCourse { PlanId = planID, CourseId = courseID, Year = year, Term = term };
			context.IajPlanCourses.Add(add);
			context.SaveChanges();
		}
	}
}