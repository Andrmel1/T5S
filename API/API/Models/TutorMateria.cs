using System;
using System.Collections.Generic;

namespace API.Models;

public partial class TutorMateria
{
    public int IdTutorMateria { get; set; }

    public int IdMateria { get; set; }

    public int IdTutor { get; set; }

    public virtual Materia IdTutorMateriaNavigation { get; set; } = null!;

    public virtual Tutor? Tutor { get; set; }
}
