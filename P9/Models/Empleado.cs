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
    public DateOnly FechaNacimiento { get; set; }
    public bool Activo { get; set; }
    public string Password { get; set; } = null!;

    public virtual ICollection<Prestamo> Prestamos { get; set; }

    public object login(int user, string pass)
    {
      using (var db = new bancoContext())
      {
        var empleado = db.Empleados.Where(u => u.Id == user && u.Password == pass).FirstOrDefault();

        if (empleado == null)
        {
          return new Exception("Usuario o contraseña inválidos");
        }

        return empleado;
      }
    }

    public object AceptarPrestamo(int id, int sid, long uid)
    {
      using (var db = new bancoContext())
      {
        var prestamo = db.Prestamos.Where(p => p.Id == id).FirstOrDefault();
        var prestamos = db.Prestamos.Where(p => p.UsuarioId == uid).ToList();
        var solicitud = db.SolicitudPrestamos.Where(p => p.Id == sid).FirstOrDefault();
        bool flag = false;
        int aid = 0;

        if (prestamo == null || solicitud == null || prestamos.Count >= 3)
        {
          return new Exception("No se encontró el prestamo o la solicitud");
        }

        foreach (var item in prestamos)
        {
          if (item.Activo == true)
          {
            flag = true;
            aid = item.Id;
          }
        }

        var ultimoPago = db.Pagos.Where(p => p.PrestamoId == aid).OrderByDescending(p => p.Fecha).FirstOrDefault();
        var prestamoActivo = db.Prestamos.Where(p => p.Id == aid).FirstOrDefault();

        if (ultimoPago == null || prestamoActivo == null)
        {
          return new Exception("No se encontró el ultimo pago o el prestamo");
        }

        if (ultimoPago.Fecha.AddMonths(1) < prestamoActivo.FechaLiquidacion)
        {
          return new Exception("No estas en el ultimo pago");
        }

        if (prestamo.FechaSolicitud.AddDays(2) > DateOnly.FromDateTime(DateTime.Now))
        {
          return new Exception("No se puede aceptar el prestamo antes de 2 días");
        }

        solicitud.Estatus = 2;
        prestamo.FechaAprobacion = DateOnly.FromDateTime(DateTime.Now);
        prestamo.FechaLiquidacion = DateOnly.FromDateTime(DateTime.Now.AddMonths(prestamo.Meses));
        db.SaveChanges();
        return prestamo;
      }
    }

    public object DenegarPrestamo(int sid)
    {
      using (var db = new bancoContext())
      {
        var solicitud = db.SolicitudPrestamos.Where(p => p.Id == sid).FirstOrDefault();

        if (solicitud == null)
        {
          return new Exception("Solicitud no existente");
        }

        solicitud.Estatus = 3;
        db.SaveChanges();
        return solicitud;
      }
    }

    public object UltimoPrestamo(int id)
    {
      using (var db = new bancoContext())
      {
        var prestamo = db.Prestamos.Where(p => p.UsuarioId == id).OrderByDescending(p => p.FechaSolicitud).FirstOrDefault();

        if (prestamo == null)
        {
          return new Exception("No hay prestamos");
        }

        return prestamo;
      }
    }

    public object UltimosPrestamos(int id)
    {
      using (var db = new bancoContext())
      {
        var prestamos = db.Prestamos.Where(p => p.UsuarioId == id).OrderByDescending(p => p.FechaSolicitud).Take(10).ToList();

        if (prestamos.Count == 0)
        {
          return new Exception("No hay prestamos");
        }

        return prestamos;
      }
    }

    public object PrestamosAceptados(int id)
    {
      using (var db = new bancoContext())
      {
        var prestamos = db.Prestamos.Where(p => p.EmpleadoId == id && p.FechaAprobacion != null).OrderByDescending(p => p.FechaSolicitud).ToList();

        if (prestamos.Count == 0)
        {
          return new Exception("No hay prestamos");
        }

        return prestamos;
      }
    }
  }
}

