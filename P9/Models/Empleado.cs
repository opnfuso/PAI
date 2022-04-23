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
  }
}
