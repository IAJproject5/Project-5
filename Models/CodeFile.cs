using Microsoft.EntityFrameworkCore;
using NuGet.Packaging.Signing;
using Project_5.Project5.Models;
using System.Collections;
using System.Linq;
public class GetQuery
{
	protected void IConfiguration(DbContextOptionsBuilder optionsBuilder)
	{
		optionsBuilder.UseMySql("name=ConnectionStrings:Project_5ContextConnection", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.27-mariadb"));
	}
	public ArrayList planIds(string uID)
	{
		using (var context = new Project_5Context())
		{
			var ids = from a in context.iaj_plans
										where a.user_id == uID
										select a.plan_id;
			int i = 0;
			var varlist = new ArrayList();
			foreach (string var in ids)
			{
				varlist.Add(var);
				i += 1;
			}
			return varlist;
		}
	}
	//May need to be changed to only return 1.
	public string planName(string pID)
	{
		using (var context = new Project_5Context())
		{
			var name = from a in context.iaj_plans
					   where a.user_id == pID
					  select a.plan_name;
			foreach (string var in name)
			{
				return var;
			}
			return "";
		}
	}
	public int catalogYear(string pID)
	{
		using (var context = new Project_5Context())
		{
			var years = from a in context.iaj_plan_courses
					   where a.plan_id == pID
					   select a.year;
			foreach (int year in years)
			{
				return year;
			}
			return 0;
		}
	}
	public ArrayList subjects(int pID)
	{
		using (var context = new Project_5Context())
		{
			var subjects = from a in context.iaj_plan_subjects
					  where a.plan_id == pID
					  select a.subject;
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
		using (var context = new Project_5Context())
		{
			var types = from a in context.iaj_plan_subjects
					  where a.plan_id == pID
					  select a.type;
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

	public ArrayList planCourses(string pID)
	{
		using (var context = new Project_5Context())
		{
			var courses = from a in context.iaj_plan_courses
					  where a.plan_id == pID
					  select a.course_id;
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

	public ArrayList planCourseTerms(string pID)
	{
		using (var context = new Project_5Context())
		{
			var terms = from a in context.iaj_plan_courses
						  where a.plan_id == pID
						  select a.term;
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

	public ArrayList planCourseYears(string pID)
	{
		using (var context = new Project_5Context())
		{
			var years = from a in context.iaj_plan_courses
						  where a.plan_id == pID
						  select a.year;
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
			using (var context = new Project_5Context())
			{
				var requirements = from a in context.iaj_requirements
							where a.year == year
							where a.subject == subjects[j]
							where a.type == subjectTypes[j]
							select a.course_id;
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
			using (var context = new Project_5Context())
			{
				var categories = from a in context.iaj_requirements
								   where a.year == year
								   where a.subject == subjects[j]
								   where a.type == subjectTypes[j]
								   select a.category;
				foreach (string category in categories)
				{
					varlist.Add(category);
					i += 1;
				}
			}
		}
		return varlist;
	}
}