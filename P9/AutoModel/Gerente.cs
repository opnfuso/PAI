using System;
using System.Collections.Generic;

namespace P9.AutoModel
{
  public partial class Gerente
  {
    public Gerente()
    {
      Prestamos = new HashSet<Prestamo>();
      Solicituds = new HashSet<Solicitud>();
    }

    public int Id { get; set; }
    public string PrimerNombre { get; set; } = null!;
    public string? SegundoNombre { get; set; }
    public string PrimerApellido { get; set; } = null!;
    public string SegundoApellido { get; set; } = null!;
    public DateTime FechaNacimiento { get; set; }
    public DateTime FechaIncorporacion { get; set; }
    public DateTime UltimasVacaciones { get; set; }
    public string Password { get; set; } = null!;

    public virtual ICollection<Prestamo> Prestamos { get; set; }
    public virtual ICollection<Solicitud> Solicituds { get; set; }
  }
}
