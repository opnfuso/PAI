using System;
using System.Collections.Generic;

namespace P11
{
  public partial class Pago
  {
    public int Id { get; set; }
    public long UsuarioId { get; set; }
    public int PrestamoId { get; set; }
    public decimal Cantidad { get; set; }
    public DateOnly Fecha { get; set; }
    public int? GerenteId { get; set; }

    public virtual Gerente? Gerente { get; set; }

    public virtual Prestamo Prestamo { get; set; } = null!;
    public virtual Usuario Usuario { get; set; } = null!;
  }
}
