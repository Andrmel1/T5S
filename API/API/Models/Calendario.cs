using System;
using System.Collections.Generic;

namespace API.Models;

public partial class Calendario
{
    public int IdCalendario { get; set; }

    public DateTime FechaCalendario { get; set; }

    public string DescripcionCalendario { get; set; } = null!;

    public virtual ResevarTutoria? ResevarTutorium { get; set; }

    public virtual Tutor? Tutor { get; set; }
}
