using System;
using System.Collections.Generic;

namespace Project_5.Project5.Models;

public partial class iaj_plan
{
    public string plan_id { get; set; } = null!;

    public string? user_id { get; set; }

    public string? plan_name { get; set; }

    public decimal? catalog { get; set; }

    public string? default_plan { get; set; }
}
