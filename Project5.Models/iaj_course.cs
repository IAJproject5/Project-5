using System;
using System.Collections.Generic;

namespace Project_5.Project5.Models;

public partial class iaj_course
{
    public string course_id { get; set; } = null!;

    public string? name { get; set; }

    public string? description { get; set; }

    public int? credits { get; set; }

    public string? prereq_id { get; set; }
}
