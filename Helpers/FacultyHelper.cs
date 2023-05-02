using Microsoft.AspNetCore.Identity;
using Project_5.Data;
using Project_5.Models;
using System.Data;

namespace Project_5.Helpers
{
	public class FacultyHelper
	{
		private static Project5Context context = new Project5Context();

		public FacultyHelper()
		{
			context = new Project5Context();
		}
		public FacultyHelper(Project5Context ctx)
		{
			context = new Project5Context();
		}
		public static List<Aspnetuser> getAdviseeList(string advisorId)
		{
			var adviseeIds = context.IajAdvisorAdvisees.Where(b => b.AdvisorId.Equals(advisorId)).ToList();
			var advisees = new List<Aspnetuser>();

            foreach (IajAdvisorAdvisee advisee in adviseeIds)
            {
                advisees.Add(context.Aspnetusers.Where(b => b.Id.Equals(advisee.AdviseeId)).FirstOrDefault());
            }
            return advisees;
		}
		public static bool isAdviseeAdvisor(string advisorId, string adviseeId)
		{
            var advisorAdvisees = context.IajAdvisorAdvisees.Where(b => b.AdvisorId.Equals(advisorId)).ToList();
			if (advisorAdvisees == null || advisorAdvisees.Count == 0)
			{
				return false;
			}
			foreach (IajAdvisorAdvisee advisorAdvisee in advisorAdvisees)
			{
				if (advisorAdvisee.AdviseeId == adviseeId)
				{
					return true;
				}
			}
			return false;
        }
	}
}
