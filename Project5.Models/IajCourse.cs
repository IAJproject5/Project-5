using System;
using System.Collections.Generic;

namespace Project_5.Project5.Models;

public partial class IajCourse
{
    public string CourseId { get; set; } = null!;

    public string? Name { get; set; }

    public string? Description { get; set; }

    public int? Credits { get; set; }

    public string? PrereqId { get; set; }
}
