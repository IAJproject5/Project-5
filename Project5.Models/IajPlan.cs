using System;
using System.Collections.Generic;

namespace Project_5.Project5.Models;

public partial class IajPlan
{
    public string PlanId { get; set; } = null!;

    public string? UserId { get; set; }

    public string? PlanName { get; set; }

    public decimal? Catalog { get; set; }

    public string? DefaultPlan { get; set; }
}
