using System;
using System.Collections.Generic;

namespace P9.AutoModel
{
  public partial class Gerente
  {
    public Gerente()
    {
      Prestamos = new HashSet<Prestamo>();
      Solicituds = new HashSet<Solicitud>();
    }

    public int Id { get; set; }
    public string PrimerNombre { get; set; } = null!;
    public string? SegundoNombre { get; set; }
    public string PrimerApellido { get; set; } = null!;
    public string SegundoApellido { get; set; } = null!;
    public DateOnly FechaNacimiento { get; set; }
    public DateOnly FechaIncorporacion { get; set; }
    public DateOnly UltimasVacaciones { get; set; }
    public string Password { get; set; } = null!;

    public virtual ICollection<Prestamo> Prestamos { get; set; }
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
  }
}
