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
        using (var db = new AutoModel.bancoContext())
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

          int usr = int.Parse(res_user);

          var cuenta = db.Cuentas.Where(u => u.Id == usr).FirstOrDefault();
          if (cuenta == null)
          {
            throw new Exception("Usuario o contraseña inválidos");
          }

          switch (cuenta.Tipo)
          {
            case 1:
              var gerente = new AutoModel.Gerente();

              var rGerente = gerente.login(cuenta.NCuentaGerente.Value, pass);

              if (rGerente is Exception)
              {
                throw (Exception)rGerente;
              }

              if (rGerente is AutoModel.Gerente)
              {
                WriteLine("\n\tBienvenido Gerente");
                manager(gerente);
              }

              break;

            case 2:
              var empleado = new AutoModel.Empleado();

              var rEmpleado = empleado.login(cuenta.NCuentaEmpleado.Value, pass);

              if (rEmpleado is Exception)
              {
                throw (Exception)rEmpleado;
              }

              if (rEmpleado is AutoModel.Empleado)
              {
                WriteLine("\n\tBienvenido Empleado");
                empleado = (AutoModel.Empleado)rEmpleado;
                employee(empleado);
              }

              break;

            case 3:
              var usuario = new AutoModel.Usuario();

              var rUsuario = usuario.login(cuenta.NCuentaUsuario.Value, pass);

              if (rUsuario is Exception)
              {
                throw (Exception)rUsuario;
              }

              if (rUsuario is AutoModel.Usuario)
              {
                WriteLine("\n\tBienvenido Usuario");
                usuario = (AutoModel.Usuario)rUsuario;
                user(usuario);
              }

              break;
            default:
              break;
          }


        }
      }
      catch (System.Exception ex)
      {
        WriteLine("\nError: " + ex.Message);
        Write("Presione una tecla para continuar...");
        Read();
      }
    }

    /* public static void loginEmpleado()
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
     }*/

    /*public static void loginAdmin()
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
          manager((AutoModel.Gerente)gerente);
        }
      }
      catch (System.Exception ex)
      {
        WriteLine("\nError: " + ex.Message);
        Write("Presione una tecla para continuar...");
        Read();
      }
    }*/
  }
}