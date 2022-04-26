using System;
using System.Collections.Generic;

namespace P9.AutoModel
{
  public partial class Prestamo
  {
    public Prestamo()
    {
      Pagos = new HashSet<Pago>();
      SolicitudPrestamos = new HashSet<SolicitudPrestamo>();
    }

    public int Id { get; set; }
    public long UsuarioId { get; set; }
    public int? EmpleadoId { get; set; }
    public int? GerenteId { get; set; }
    public int Meses { get; set; }
    public decimal Cantidad { get; set; }
    public decimal Interes { get; set; }
    public decimal PagoMes { get; set; }
    public DateOnly FechaSolicitud { get; set; }
    public DateOnly? FechaAprobacion { get; set; } = null!;
    public DateOnly? FechaLiquidacion { get; set; } = null!;
    public bool Activo { get; set; }

    public DateOnly? FechaPausa { get; set; } = null!;

    public virtual Empleado? Empleado { get; set; }
    public virtual Gerente? Gerente { get; set; }
    public virtual Usuario Usuario { get; set; } = null!;
    public virtual ICollection<Pago> Pagos { get; set; }
    public virtual ICollection<SolicitudPrestamo> SolicitudPrestamos { get; set; }
  }
}
