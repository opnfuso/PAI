using System;
using System.Collections.Generic;
using static System.Console;

namespace P9.AutoModel
{
  public partial class Usuario
  {
    public Usuario()
    {
      Pagos = new HashSet<Pago>();
      Prestamos = new HashSet<Prestamo>();
      SolicitudPrestamos = new HashSet<SolicitudPrestamo>();
      Solicituds = new HashSet<Solicitud>();
    }

    public long Id { get; set; }
    public int PersonaId { get; set; }
    public string NombreUsuario { get; set; } = null!;
    public string Password { get; set; } = null!;
    public decimal Saldo { get; set; }
    public bool Activo { get; set; }
    public int Intentos { get; set; }
    public DateTime? TiempoBloqueo { get; set; }

    public DateOnly? FechaBaja { get; set; }

    public virtual Persona Persona { get; set; } = null!;
    public virtual ICollection<Cuenta> Cuenta { get; set; }
    public virtual ICollection<Pago> Pagos { get; set; }
    public virtual ICollection<Prestamo> Prestamos { get; set; }
    public virtual ICollection<SolicitudPrestamo> SolicitudPrestamos { get; set; }
    public virtual ICollection<Solicitud> Solicituds { get; set; }

    public object login(long id, string pass)
    {
      using (var db = new bancoContext())
      {
        var usuario = db.Usuarios.Where(u => u.Id == id).FirstOrDefault();

        if (usuario == null)
        {
          return new Exception("Usuario o contraseña inválidos");
        }

        if (usuario.Activo == false)
        {
          return new Exception("Usuario inactivo");
        }

        if (usuario.TiempoBloqueo != null && usuario.TiempoBloqueo > DateTime.Now)
        {
          return new Exception("Usuario bloqueado");
        }

        if (usuario.Password != pass)
        {
          usuario.Intentos++;
          if (usuario.Intentos >= 3)
          {
            usuario.TiempoBloqueo = DateTime.Now.AddMinutes(5);
            WriteLine("\nUsuario bloqueado por 5 minutos");
          }
          else
          {
            WriteLine($"Quedan {3 - usuario.Intentos} intentos");
          }
          db.SaveChanges();
          return new Exception("Contraseña incorrecta");
        }

        usuario.Intentos = 0;

        return usuario;
      }
    }

    public object verPrestamoActivo(Usuario user)
    {
      using (var db = new bancoContext())
      {
        var prestamo = db.Prestamos.Where(p => p.UsuarioId == user.Id && p.Activo == true).FirstOrDefault();

        if (prestamo == null)
        {
          return new Exception("No tiene prestamos activos");
        }

        return prestamo;
      }
    }

    public object verHistorial(long id)
    {
      using (var db = new bancoContext())
      {
        var pagos = db.Pagos.Where(p => p.UsuarioId == id).ToList();

        if (pagos.Count == 0)
        {
          return new Exception("No tiene pagos");
        }

        return pagos;
      }
    }

    public object Create(int id_Persona, string Pname, string Pap, string Sap, DateOnly bornday, int gid)
    {
      using (var db = new bancoContext())
      {
        var user = new AutoModel.Usuario();
        user.PersonaId = id_Persona;
        user.NombreUsuario = Pname + "_" + Pap + Sap;
        user.Password = bornday.ToString("ddMMyy");
        user.Saldo = 10000;
        user.Activo = true;
        user.Intentos = 0;
        #region Randomizer
        Random rnd = new Random();
        long id_u;
        bool idFlag;
        do
        {
          id_u = rnd.NextInt64(1, 999999999);
          idFlag = db.Usuarios.Where(u => u.Id == id_u).Any();
        } while (idFlag == true);
        #endregion
        var person = db.Solicituds.Where(u => u.PersonaId == id_Persona).FirstOrDefault();
        person.UsuarioId = id_u;
        person.GerenteId = gid;
        user.Id = id_u;
        db.Usuarios.Add(user);
        db.SaveChanges();

        var cuenta = new AutoModel.Cuenta();
        cuenta.NCuentaUsuario = id_u;
        cuenta.Tipo = 3;
        db.Cuentas.Add(cuenta);
        db.SaveChanges();

        return user;
      }
    }

    public object AddSaldo(long id, decimal saldo)
    {
      using (var db = new bancoContext())
      {
        var user = db.Usuarios.Where(u => u.Id == id).FirstOrDefault();
        if (user == null)
        {
          return new Exception("Usuario no encontrado");
        }
        user.Saldo += saldo;
        db.SaveChanges();
        return user;
      }
    }
  }
}
