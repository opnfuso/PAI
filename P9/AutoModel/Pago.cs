using System;
using System.Collections.Generic;

namespace P9.AutoModel
{
  public partial class Pago
  {
    public int Id { get; set; }
    public int UsuarioId { get; set; }
    public int PrestamoId { get; set; }
    public decimal Cantidad { get; set; }
    public DateTime Fecha { get; set; }

    public virtual Prestamo Prestamo { get; set; } = null!;
    public virtual Usuario Usuario { get; set; } = null!;
  }
}
