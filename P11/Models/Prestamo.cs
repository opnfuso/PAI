using System;
using System.Collections.Generic;

namespace P11
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
    public DateTime FechaSolicitud { get; set; }
    public DateTime? FechaAprobacion { get; set; } = null!;
    public DateTime? FechaLiquidacion { get; set; } = null!;
    public bool Activo { get; set; }

    public DateTime? FechaPausa { get; set; } = null!;

    public virtual Empleado? Empleado { get; set; }
    public virtual Gerente? Gerente { get; set; }
    public virtual Usuario Usuario { get; set; } = null!;
    public virtual ICollection<Pago> Pagos { get; set; }
    public virtual ICollection<SolicitudPrestamo> SolicitudPrestamos { get; set; }

    public object Create(long UsuarioId, decimal saldo, decimal monto, int meses)
    {
      using (var db = new bancoContext())
      {
        var prestamo = new Prestamo();

        prestamo.UsuarioId = UsuarioId;

        prestamo.Cantidad = monto;

        if (prestamo.Cantidad > (saldo / 2))
        {
          return new Exception("El Monto no puede exceder el 50% del Saldo del Usuario.");
        }

        prestamo.Meses = meses;

        if (!(prestamo.Meses == 6 || prestamo.Meses == 12 || prestamo.Meses == 24 || prestamo.Meses == 36))
        {
          return new Exception("Los meses solo pueden ser 6,12,24 o 36");
        }

        switch (prestamo.Meses)
        {
          case 6:
            {
              prestamo.Interes = 12;
              break;
            }
          case 12:
            {
              prestamo.Interes = 18;
              break;
            }
          case 24:
            {
              prestamo.Interes = 27.9M;
              break;
            }
          case 36:
            {
              prestamo.Interes = 42;
              break;
            }
        }

        prestamo.PagoMes = (prestamo.Cantidad / prestamo.Meses) + ((prestamo.Cantidad / prestamo.Meses) * prestamo.Interes / 100);

        var time = DateTime.Now;
        prestamo.FechaSolicitud = time;

        prestamo.FechaLiquidacion = prestamo.FechaSolicitud.AddMonths(prestamo.Meses);

        prestamo.Activo = false;

        db.Prestamos.Add(prestamo);
        db.SaveChanges();

        var SoliPrestamo = new SolicitudPrestamo()
        {
          UsuarioId = prestamo.UsuarioId,
          PrestamoId = prestamo.Id,
          Estatus = 1

        };

        db.SolicitudPrestamos.Add(SoliPrestamo);
        db.SaveChanges();


        return prestamo;
      }
    }

  }
}
