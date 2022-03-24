using System;
using static System.Console;
namespace P7
{
  public partial class Program
  {
    #region listas
    static List<Usuario> usuarios = new List<Usuario>();
    static List<Empleado> empleados = new List<Empleado>();
    static List<Gerente> gerentes = new List<Gerente>();
    static List<Prestamo> prestamos = new List<Prestamo>();
    #endregion
    static void Main(string[] args)
    {
      var user = new Usuario(1, "Juan", "Perez", DateOnly.Parse("01/01/2000"));
      user.setNip(1234);
      usuarios.Add(user);
      var empleado = new Empleado(2, "Pedro", "Perez", DateOnly.Parse("01/01/2000"));
      empleados.Add(empleado);
      var gerente = new Gerente(3);
      gerente.setMasterPassword("password");
      gerentes.Add(gerente);
      menu();
    }
  }
}