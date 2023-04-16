using System;
using System.Collections.Generic;

namespace Project_5.Models;

public partial class IajRequirement
{
    public decimal? Year { get; set; }

    public string? Subject { get; set; }

    public string? Type { get; set; }

    public string? Category { get; set; }

    public string? CourseId { get; set; }
}
