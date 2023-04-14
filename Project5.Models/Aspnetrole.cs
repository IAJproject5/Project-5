﻿using System;
using System.Collections.Generic;

namespace Project_5.Project5.Models;

public partial class aspnetrole
{
    public string Id { get; set; } = null!;

    public string? Name { get; set; }

    public string? NormalizedName { get; set; }

    public string? ConcurrencyStamp { get; set; }

    public virtual ICollection<aspnetroleclaim> aspnetroleclaims { get; } = new List<aspnetroleclaim>();

    public virtual ICollection<aspnetuser> Users { get; } = new List<aspnetuser>();
}
