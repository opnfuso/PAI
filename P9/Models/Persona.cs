using System;
using System.Collections.Generic;

namespace P9.AutoModel
{
  public partial class Persona
  {
    public Persona()
    {
      Solicituds = new HashSet<Solicitud>();
    }

    public int Id { get; set; }
    public string PrimerNombre { get; set; } = null!;
    public string? SegundoNombre { get; set; }
    public string PrimerApellido { get; set; } = null!;
    public string SegundoApellido { get; set; } = null!;
    public DateOnly FechaNacimiento { get; set; }
    public string Curp { get; set; } = null!;

    public virtual Usuario Usuario { get; set; } = null!;
    public virtual ICollection<Solicitud> Solicituds { get; set; }
  }
}
