using System;
using static System.Console;

namespace P9
{
  partial class Program
  {
    public static void login()
    {
      try
      {
        WriteLine("\n\tBanco de Préstamos");
        Write("Ingrese su nombre de usuario: ");
        string? res_user = ReadLine();
        Write("Ingrese su contraseña: ");
        string? pass = ReadLine();

        if (res_user == null || pass == null)
        {
          throw new Exception("Usuario o contraseña inválidos");
        }

        var Usuario = new AutoModel.Usuario();
        var usuario = Usuario.login(res_user, pass);

        if (usuario is Exception)
        {
          throw (Exception)usuario;
        }

        if (usuario is AutoModel.Usuario)
        {
          // WriteLine("\nBienvenido " + ((AutoModel.Usuario)usuario).NombreUsuario);
          // Write("Presione una tecla para continuar...");
          // Read();
          user((AutoModel.Usuario)usuario);
        }
      }
      catch (System.Exception ex)
      {
        WriteLine("\nError: " + ex.Message);
        Write("Presione una tecla para continuar...");
        Read();
      }
    }

    public static void loginEmpleado()
    {
      try
      {
        WriteLine("\n\tBanco de Préstamos");
        Write("Ingrese su número de nomina: ");
        string? user = ReadLine();
        Write("Ingrese su contraseña: ");
        string? pass = ReadLine();

        if (user == null || pass == null)
        {
          throw new Exception("Usuario o contraseña inválidos");
        }

        int usr = int.Parse(user);

        var Empleado = new AutoModel.Empleado();
        var empleado = Empleado.login(usr, pass);

        if (empleado is Exception)
        {
          throw (Exception)empleado;
        }

        if (empleado is AutoModel.Empleado)
        {
          employee((AutoModel.Empleado)empleado);
        }
      }
      catch (System.Exception ex)
      {
        WriteLine("\nError: " + ex.Message);
        Write("Presione una tecla para continuar...");
        Read();
      }
    }

    public static void loginAdmin()
    {
      try
      {
        WriteLine("\n\tBanco de Préstamos");
        Write("Ingrese su número de nomina: ");
        string? user = ReadLine();
        Write("Ingrese su contraseña: ");
        string? pass = ReadLine();

        if (user == null || pass == null)
        {
          throw new Exception("Usuario o contraseña inválidos");
        }

        int usr = int.Parse(user);

        var Gerente = new AutoModel.Gerente();
        var gerente = Gerente.login(usr, pass);

        if (gerente is Exception)
        {
          throw (Exception)gerente;
        }

        if (gerente is AutoModel.Gerente)
        {
          WriteLine("\nBienvenido " + ((AutoModel.Gerente)gerente).PrimerNombre + " " + ((AutoModel.Gerente)gerente).PrimerApellido);
          Write("Presione una tecla para continuar...");
          Read();
        }
      }
      catch (System.Exception ex)
      {
        WriteLine("\nError: " + ex.Message);
        Write("Presione una tecla para continuar...");
        Read();
      }
    }
  }
}