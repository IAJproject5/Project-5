using Microsoft.EntityFrameworkCore;
using NuGet.Packaging.Signing;
using Project_5.Project5.Models;
using System.Collections;
using System.Linq;

public class GetQuery
{
	public ArrayList planIds(string uID)
	{
		using (var context = new Project_5Context())
		{
			var ids = from a in context.IajPlans
										where a.UserId == uID
										select a.PlanId;
			int i = 0;
			var varlist = new ArrayList();
			foreach (string var in ids)
			{
				varlist[i] = var;
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
			var name = from a in context.IajPlans
					   where a.UserId == pID
					  select a.PlanName;
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
			var years = from a in context.IajPlanCourses
					   where a.PlanId == pID
					   select a.Year;
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
			var subjects = from a in context.IajPlanSubjects
					  where a.PlanId == pID
					  select a.Subject;
			int i = 0;
			var varlist = new ArrayList();
			foreach (string subject in subjects)
			{
				varlist[i] = subject;
				i += 1;
			}
			return varlist;
		}
	}
	public ArrayList subjectTypes(int pID)
	{
		using (var context = new Project_5Context())
		{
			var types = from a in context.IajPlanSubjects
					  where a.PlanId == pID
					  select a.Type;
			int i = 0;
			var varlist = new ArrayList();
			foreach (string type in types)
			{
				varlist[i] = type;
				i += 1;
			}
			return varlist;
		}
	}
	//Needed? Requirements? Courses?
}