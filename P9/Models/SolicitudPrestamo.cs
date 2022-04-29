using System;
using System.Collections.Generic;

namespace P9.AutoModel
{
  public partial class SolicitudPrestamo
  {
    public int Id { get; set; }
    public long UsuarioId { get; set; }
    public int PrestamoId { get; set; }
    public int Estatus { get; set; }
    public virtual Prestamo Prestamo { get; set; } = null!;
    public virtual Usuario Usuario { get; set; } = null!;
  }
}
