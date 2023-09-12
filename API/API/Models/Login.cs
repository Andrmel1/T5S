﻿using System;
using System.Collections.Generic;

namespace API.Models;

public partial class Login
{
    public int IdLogin { get; set; }

    public string User { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual Estudiante IdLoginNavigation { get; set; } = null!;

    public virtual Tutor? Tutor { get; set; }
}
