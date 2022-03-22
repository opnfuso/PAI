using System;
using static System.Console;
namespace P7
{
  class Program
  {
    #region listas
    static List<Usuario> usuarios = new List<Usuario>();
    static List<Empleado> empleados = new List<Empleado>();
    static List<Gerente> gerentes = new List<Gerente>();
    static List<Prestamo> prestamos = new List<Prestamo>();
    #endregion
    static void Main(string[] args)
    {
      var user = new Usuario();
      user.num_cuenta = 1;
      user.setNip(1234);
      usuarios.Add(user);
      menu();
    }

    static void menu()
    {
      WriteLine();
      WriteLine("1. Usuario");
      WriteLine("2. Empleado");
      WriteLine("3. Gerente");
      Write("Identificate : ");
      string? res = ReadLine();
      Int16 ans = Int16.Parse(res);

      switch (ans)
      {
        case 1:
          Write("\nIngresa tu numero de cuenta : ");
          res = ReadLine();
          uint ncuenta = uint.Parse(res);
          IEnumerable<Usuario> users = usuarios.Where(usuario => usuario.num_cuenta == ncuenta);
          if (users.LongCount() == 0)
          {
            WriteLine("No existe ese numero de cuenta");
            return;
          }

          Write("Ingresa tu NIP : ");
          res = ReadLine();
          uint nip = uint.Parse(res);
          if (users.ElementAt(0).validateNip(nip))
          {
            WriteLine("Pedir prestamo");
            // Complete with a case for the 2 options
          }
          else
          {
            WriteLine("El nip es incorrecto");
          }
          break;

        default:
          break;
      }
    }
  }
}