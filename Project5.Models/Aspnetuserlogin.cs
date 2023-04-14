﻿using System;
using System.Collections.Generic;

namespace Project_5.Project5.Models;

public partial class aspnetuserlogin
{
    public string LoginProvider { get; set; } = null!;

    public string ProviderKey { get; set; } = null!;

    public string? ProviderDisplayName { get; set; }

    public string UserId { get; set; } = null!;

    public virtual aspnetuser User { get; set; } = null!;
}
