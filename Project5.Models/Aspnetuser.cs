using System;
using System.Collections.Generic;

namespace Project_5.Project5.Models;

public partial class aspnetuser
{
    public string Id { get; set; } = null!;

    public string? UserName { get; set; }

    public string? NormalizedUserName { get; set; }

    public string? Email { get; set; }

    public string? NormalizedEmail { get; set; }

    public bool EmailConfirmed { get; set; }

    public string? PasswordHash { get; set; }

    public string? SecurityStamp { get; set; }

    public string? ConcurrencyStamp { get; set; }

    public string? PhoneNumber { get; set; }

    public bool PhoneNumberConfirmed { get; set; }

    public bool TwoFactorEnabled { get; set; }

    public DateTime? LockoutEnd { get; set; }

    public bool LockoutEnabled { get; set; }

    public int AccessFailedCount { get; set; }

    public virtual ICollection<aspnetuserclaim> aspnetuserclaims { get; } = new List<aspnetuserclaim>();

    public virtual ICollection<aspnetuserlogin> aspnetuserlogins { get; } = new List<aspnetuserlogin>();

    public virtual ICollection<aspnetusertoken> aspnetusertokens { get; } = new List<aspnetusertoken>();

    public virtual ICollection<aspnetrole> Roles { get; } = new List<aspnetrole>();
}
