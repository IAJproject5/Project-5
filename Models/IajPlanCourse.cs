using System;
using System.Collections.Generic;

namespace Project_5.Models;

public partial class IajPlanCourse
{
    public int PlanId { get; set; }

    public string? CourseId { get; set; }

    public int? Year { get; set; }

    public string? Term { get; set; }
}
