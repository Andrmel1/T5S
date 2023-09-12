using System;
using System.Collections.Generic;

namespace API.Models;

public partial class Materia
{
    public int IdMateria { get; set; }

    public string NombreMateria { get; set; } = null!;

    public string CostoMateria { get; set; } = null!;

    public string PruebaMateria { get; set; } = null!;

    public int IdTutorMateria { get; set; }

    public virtual ResevarTutoria? ResevarTutorium { get; set; }

    public virtual TutorMateria? TutorMaterium { get; set; }
}
