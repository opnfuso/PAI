using System;
using System.Collections.Generic;

namespace P9.AutoModel
{
  public partial class Empleado
  {
    public Empleado()
    {
      Prestamos = new HashSet<Prestamo>();
    }

    public int Id { get; set; }
    public string PrimerNombre { get; set; } = null!;
    public string? SegundoNombre { get; set; }
    public string PrimerApellido { get; set; } = null!;
    public string SegundoApellido { get; set; } = null!;
    public DateTime FechaNacimiento { get; set; }
    public bool Activo { get; set; }
    public string Password { get; set; } = null!;

    public virtual ICollection<Prestamo> Prestamos { get; set; }
  }
}
