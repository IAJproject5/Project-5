using System;
using System.Collections.Generic;

namespace Project_5.Project5.Models;

public partial class Aspnetrole
{
    public string Id { get; set; } = null!;

    public string? Name { get; set; }

    public string? NormalizedName { get; set; }

    public string? ConcurrencyStamp { get; set; }

    public virtual ICollection<Aspnetroleclaim> Aspnetroleclaims { get; } = new List<Aspnetroleclaim>();

    public virtual ICollection<Aspnetuser> Users { get; } = new List<Aspnetuser>();
}
