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
    public int UsuarioId { get; set; }
    public int? EmpleadoId { get; set; }
    public int? GerenteId { get; set; }
    public int Meses { get; set; }
    public decimal Cantidad { get; set; }
    public decimal Interes { get; set; }
    public decimal PagoMes { get; set; }
    public DateTime FechaSolicitud { get; set; }
    public DateTime? FechaAprobacion { get; set; }
    public DateTime? FechaLiquidacion { get; set; }
    public bool Activo { get; set; }

    public virtual Empleado? Empleado { get; set; }
    public virtual Gerente? Gerente { get; set; }
    public virtual Usuario Usuario { get; set; } = null!;
    public virtual ICollection<Pago> Pagos { get; set; }
    public virtual ICollection<SolicitudPrestamo> SolicitudPrestamos { get; set; }
  }
}
