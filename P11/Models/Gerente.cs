using System;
using System.Collections.Generic;

namespace P11
{
  public partial class Gerente
  {
    public Gerente()
    {
      Prestamos = new HashSet<Prestamo>();
      Solicituds = new HashSet<Solicitud>();
      Pagos = new HashSet<Pago>();
      Cuenta = new HashSet<Cuenta>();
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
    public int? DiasVaca { get; set; }
    public int? DiasSeguidos { get; set; }
    public decimal Saldo { get; set; }

    public virtual ICollection<Cuenta> Cuenta { get; set; }
    public virtual ICollection<Prestamo> Prestamos { get; set; }
    public virtual ICollection<Pago> Pagos { get; set; }
    public virtual ICollection<Solicitud> Solicituds { get; set; }

    public object login(int user, string pass)
    {
      using (var db = new bancoContext())
      {
        var gerente = db.Gerentes.Where(u => u.Id == user && u.Password == pass).FirstOrDefault();

        if (gerente == null)
        {
          return new Exception("Usuario o contraseña inválidos");
        }

        return gerente;
      }
    }

    public object Create(string Pa, string Sa, string Pn, string Sn, string pass, DateTime nacimiento)
    {
      using (var db = new bancoContext())
      {
        if (Pn == null || Pa == null || Sa == null || pass == null)
        {
          return new Exception("Algun dato es nulo");
        }

        bool flag = Pn.Any(char.IsDigit);
        if (flag == true)
        {
          return new Exception("Los Nombres no pueden llevar numeros..");
        }
        flag = Pn.Any(char.IsSymbol);
        if (flag == true)
        {
          return new Exception("Los Nombres no pueden llevar simbolos..");
        }

        if (Sn is not null)
        {
          flag = Sn.Any(char.IsDigit);
          if (flag == true)
          {
            return new Exception("Los Nombres no pueden llevar numeros..");
          }
          flag = Sn.Any(char.IsSymbol);
          if (flag == true)
          {
            return new Exception("Los Nombres no pueden llevar simbolos..");
          }
        }

        flag = Pa.Any(char.IsDigit);
        if (flag == true)
        {
          return new Exception("Los Apellidos no pueden llevar numeros..");
        }
        flag = Pa.Any(char.IsSymbol);
        if (flag == true)
        {
          return new Exception("Los Apellidos no pueden llevar simbolos..");
        }

        flag = Sa.Any(char.IsDigit);
        if (flag == true)
        {
          return new Exception("Los Apellidos no pueden llevar numeros..");
        }
        flag = Sa.Any(char.IsSymbol);
        if (flag == true)
        {
          return new Exception("Los Apellidos no pueden llevar simbolos..");
        }

        var gerente = new Gerente();

        gerente.PrimerNombre = Pn;
        gerente.SegundoNombre = Sn;
        gerente.PrimerApellido = Pa;
        gerente.SegundoApellido = Sa;
        gerente.Password = pass;
        gerente.FechaIncorporacion = DateTime.Now;
        gerente.FechaNacimiento = nacimiento;

        db.Gerentes.Add(gerente);
        db.SaveChanges();

        var cuenta = new Cuenta();
        cuenta.NCuentaGerente = gerente.Id;
        cuenta.Tipo = 1;
        db.Cuentas.Add(cuenta);
        db.SaveChanges();

        return gerente;
      }
    }

    public object AceptarPrestamo(int id, int sid, long uid)
    {
      using (var db = new bancoContext())
      {
        var prestamo = db.Prestamos.Where(p => p.Id == id).FirstOrDefault();
        var prestamos = db.Prestamos.Where(p => p.UsuarioId == uid).ToList();
        var solicitud = db.SolicitudPrestamos.Where(p => p.Id == sid).FirstOrDefault();
        int aid = 0;

        if (prestamo == null || solicitud == null || prestamos.Count >= 3)
        {
          return new Exception("No se encontró el prestamo o la solicitud");
        }

        foreach (var item in prestamos)
        {
          if (item.Activo == true)
          {
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

        if (prestamo.FechaSolicitud.AddDays(2) > DateTime.Now)
        {
          return new Exception("No se puede aceptar el prestamo antes de 2 días");
        }

        solicitud.Estatus = 2;
        prestamo.FechaAprobacion = DateTime.Now;
        prestamo.FechaLiquidacion = DateTime.Now.AddMonths(prestamo.Meses);
        prestamo.Activo = true;

        for (int i = 0; i < prestamo.Meses; i++)
        {
          var pago = new Pago
          {
            PrestamoId = prestamo.Id,
            UsuarioId = prestamo.UsuarioId,
            Cantidad = prestamo.PagoMes / prestamo.Meses,
            Fecha = DateTime.Now.AddMonths(i + 1)
          };

          db.Pagos.Add(pago);
        }

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

    public object CrearPrestamo(int gid, decimal cantidad, int meses)
    {
      using (var db = new bancoContext())
      {
        var gerente = db.Gerentes.Where(g => g.Id == gid).FirstOrDefault();
        var cuenta = db.Cuentas.Where(c => c.NCuentaGerente == gid).FirstOrDefault();
        var prestamo = new Prestamo();

        if (gerente == null || cuenta == null)
        {
          return new Exception("Gerente o cuenta no existente");
        }

        if (cantidad <= 0)
        {
          return new Exception("La cantidad debe ser mayor a 0");
        }

        if (meses != 6 && meses != 12 && meses != 24 && meses != 36)
        {
          return new Exception("El numero de meses debe ser 6, 12, 24 o 36");
        }

        prestamo.Meses = meses;
        prestamo.Cantidad = cantidad;
        prestamo.GerenteId = gerente.Id;
        prestamo.FechaSolicitud = DateTime.Now;
        prestamo.FechaAprobacion = DateTime.Now; ;
        prestamo.FechaLiquidacion = DateTime.Now.AddMonths(meses);
        prestamo.Activo = true;
        prestamo.Interes = 10.2m;
        prestamo.PagoMes = (prestamo.Cantidad / prestamo.Meses) + ((prestamo.Cantidad / prestamo.Meses) * prestamo.Interes / 100);

        for (int i = 0; i < prestamo.Meses; i++)
        {
          var pago = new Pago
          {
            PrestamoId = prestamo.Id,
            UsuarioId = prestamo.UsuarioId,
            Cantidad = prestamo.PagoMes / prestamo.Meses,
            Fecha = DateTime.Now.AddMonths(i + 1)
          };

          db.Pagos.Add(pago);
        }

        db.Prestamos.Add(prestamo);
        db.SaveChanges();

        return prestamo;
      }
    }

    public object BajaEmpleado(int id)
    {
      using (var db = new bancoContext())
      {
        var empleado = db.Empleados.Where(e => e.Id == id).FirstOrDefault();

        if (empleado == null)
        {
          return new Exception("Empleado no existente");
        }

        empleado.Activo = false;
        db.SaveChanges();
        return empleado;
      }
    }

    public object BajaUsuario(int id)
    {
      using (var db = new bancoContext())
      {
        var usuario = db.Usuarios.Where(u => u.Id == id).FirstOrDefault();
        var prestamos = db.Prestamos.Where(p => p.UsuarioId == id).ToList();

        if (usuario == null || prestamos.Count > 0)
        {
          return new Exception("Usuario o prestamos no existentes");
        }

        foreach (var item in prestamos)
        {
          if (DateTime.Now < item.FechaAprobacion.Value.AddMonths(6))
          {
            return new Exception("No se puede dar de baja el usuario, el ultimo registro debe ser mayor a 6 meses");
          }
        }

        usuario.Activo = false;
        usuario.FechaBaja = DateTime.Now;
        db.SaveChanges();
        return usuario;
      }
    }

    public object PausarPrestamo(int id)
    {
      using (var db = new bancoContext())
      {
        var prestamo = db.Prestamos.Where(p => p.Id == id).FirstOrDefault();

        if (prestamo == null)
        {
          return new Exception("Prestamo no existente");
        }

        prestamo.Activo = false;
        prestamo.FechaPausa = DateTime.Now;
        db.SaveChanges();
        return prestamo;
      }
    }

    public object ReanudarPrestamo(int id)
    {
      using (var db = new bancoContext())
      {
        var prestamo = db.Prestamos.Where(p => p.Id == id).FirstOrDefault();
        if (prestamo == null)
        {
          return new Exception("Prestamo no existente");
        }

        var pagos = db.Pagos.Where(p => p.PrestamoId == id && p.Fecha > prestamo.FechaPausa).ToList();

        if (pagos.Count <= 0)
        {
          return new Exception("No se puede reaudar el prestamo, no hay pagos posteriores a la fecha de pausa");
        }

        foreach (var pago in pagos)
        {
          var diff = DateTime.Now.Subtract(pago.Fecha);
          var presta = db.Prestamos.Where(p => p.Id == pago.PrestamoId).FirstOrDefault();

          if (presta is null)
          {
            return new Exception("Prestamo no existente");
          }

          pago.Fecha = pago.Fecha.AddDays(diff.Days);

          presta.FechaLiquidacion = presta.FechaLiquidacion.Value.AddDays(diff.Days);
        }

        prestamo.Activo = true;
        prestamo.FechaPausa = null;
        db.SaveChanges();
        return prestamo;
      }
    }

    public object AddSaldo(int id, decimal cantidad)
    {
      using (var db = new bancoContext())
      {
        var gerente = db.Gerentes.Where(c => c.Id == id).FirstOrDefault();
        if (gerente == null)
        {
          return new Exception("Cuenta no existente");
        }

        gerente.Saldo += cantidad;
        db.SaveChanges();
        return gerente;
      }
    }
  }
}
