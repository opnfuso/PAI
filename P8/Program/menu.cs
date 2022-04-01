using System;
using static System.Console;
namespace P7
{
  public partial class Program
  {
    static void menu()
    {
      bool end = false;
      do
      {
        try
        {
          WriteLine();
          WriteLine("1. Usuario");
          WriteLine("2. Empleado");
          WriteLine("3. Gerente");
          WriteLine("4. Salir");
          Write("Opcion : ");
          string? res = ReadLine();
          Int16 ans = Int16.Parse(res);

          if (ans <= 0)
          {
            throw new Exception("No se pueden numeros negativos");
          }

          switch (ans)
          {
            case 1:
              {
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
                if (users.ElementAt(0).nip == nip)
                {
                  WriteLine("1. Pedir un prestamo");
                  WriteLine("2. Ver tus prestamos");
                  Write("Opcion : ");
                  res = ReadLine();

                  switch (int.Parse(res))
                  {
                    case 1:
                      crear_prestamo(ncuenta);
                      break;
                    case 2:
                      mis_prestamos(ncuenta);
                      break;
                    default:
                      break;
                  }

                }
                else
                {
                  WriteLine("El nip es incorrecto");
                }
              }
              break;

            case 2:
              {
                Write("\nIngresa tu numero de cuenta : ");
                res = ReadLine();
                uint nempleado = uint.Parse(res);
                IEnumerable<Empleado> workers = empleados.Where(empleado => empleado.num_empleado == nempleado);
                if (workers.LongCount() == 0)
                {
                  WriteLine("No existe ese numero de empleado");
                  return;
                }

                WriteLine("1. Crear un usuario");
                WriteLine("2. Crear un empleado");
                Write("Opcion : ");
                res = ReadLine();

                switch (int.Parse(res))
                {
                  case 1:
                    crear_usuario();
                    break;
                  case 2:
                    crear_empleado();
                    break;
                  default:
                    break;
                }


              }
              break;

            case 3:
              {
                Write("\nIngresa tu numero de cuenta : ");
                res = ReadLine();
                uint ngerente = uint.Parse(res);
                IEnumerable<Gerente> managers = gerentes.Where(gerente => gerente.num_empleado == ngerente);
                if (managers.LongCount() == 0)
                {
                  WriteLine("No existe ese numero de gerente");
                  return;
                }


                Write("Ingresa la password maestra : ");
                res = ReadLine();

                if (managers.ElementAt(0).master_pass != res)
                {
                  WriteLine("Password incorrecta");
                  return;
                }

                WriteLine("1. Crear un usuario");
                WriteLine("2. Crear un empleado");
                WriteLine("3. Crear un gerente");
                Write("Opcion : ");
                res = ReadLine();

                switch (int.Parse(res))
                {
                  case 1:
                    crear_usuario();
                    break;
                  case 2:
                    crear_empleado();
                    break;
                  case 3:
                    crear_gerente();
                    break;
                  default:
                    break;
                }
              }
              break;

            case 4:
              {
                end = true;
              }
              break;
            default:
              break;
          }
        }
        catch (System.Exception error)
        {
          WriteLine(error.Message);
        }

      } while (end == false);


    }
  }
}