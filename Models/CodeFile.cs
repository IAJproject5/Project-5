using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Project_5.Project_5.Models;

internal class Test
{
	private static void Main()
	{
		using (var context = new Project_5Context())
		{
			var tabs = context.IajPlans.ToList();
		}
	}
}