using System;
using System.Collections.Generic;

namespace API.Models;

public partial class Geografia
{
    public int IdGeografia { get; set; }

    public string Ciudad { get; set; } = null!;

    public string Pais { get; set; } = null!;

    public virtual ResevarTutoria? ResevarTutorium { get; set; }
}
