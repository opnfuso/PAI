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

    public int Id { get; set; }
    public int PersonaId { get; set; }
    public string NombreUsuario { get; set; } = null!;
    public string Password { get; set; } = null!;
    public decimal Saldo { get; set; }
    public bool Activo { get; set; }
    public int Intentos { get; set; }
    public DateTime? TiempoBloqueo { get; set; }

    public virtual Persona Persona { get; set; } = null!;
    public virtual ICollection<Pago> Pagos { get; set; }
    public virtual ICollection<Prestamo> Prestamos { get; set; }
    public virtual ICollection<SolicitudPrestamo> SolicitudPrestamos { get; set; }
    public virtual ICollection<Solicitud> Solicituds { get; set; }

    public object login(string user, string pass)
    {
      using (var db = new bancoContext())
      {
        var usuario = db.Usuarios.Where(u => u.NombreUsuario == user).FirstOrDefault();

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
  }
}
