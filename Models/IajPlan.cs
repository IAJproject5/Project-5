using System;
using System.Collections.Generic;

namespace Project_5.Models;

public partial class IajPlan
{
    public int PlanId { get; set; }

    public string? UserId { get; set; }

    public string? PlanName { get; set; }

    public decimal? Catalog { get; set; }

    public string? DefaultPlan { get; set; }
}
