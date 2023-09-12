using System;
using System.Collections.Generic;

namespace API.Models;

public partial class FormaPago
{
    public int IdPago { get; set; }

    public string TipoPago { get; set; } = null!;

    public int ValoraPagar { get; set; }

    public virtual ResevarTutoria? ResevarTutorium { get; set; }
}
