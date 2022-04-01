using System;
using static System.Console;
namespace P7
{
  public partial class Program
  {
    static void Main(string[] args)
    {
      EmpleadoJsonDeserialization();
      UsuarioJsonDeserialization();
      GerenteJsonDeserialization();
      PrestamoJsonDeserialization();

      if (gerentes.Count == 0)
      {
        var gerente = new Gerente(3, "password");
        gerentes.Add(gerente);
        GerenteJsonSerialization(gerentes);
      }

      if (usuarios.Count == 0)
      {
        var user = new Usuario(1, "Juan", "Perez", DateTime.Parse("01/01/2000"), 1234);
        usuarios.Add(user);
        UsuarioJsonSerialization(usuarios);
      }

      if (empleados.Count == 0)
      {
        var empleado = new Empleado(2, "Pedro", "Perez", DateTime.Parse("01/01/2000"));
        empleados.Add(empleado);
        EmpleadoJsonSerialization(empleados);
      }

      EmpleadoXmlSerialization(empleados);
      UsuarioXmlSerialization(usuarios);
      GerenteXmlSerialization(gerentes);

      menu();
    }
  }
}