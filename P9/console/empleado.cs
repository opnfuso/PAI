using System;
using static System.Console;

namespace P9
{
  partial class Program
  {
    public static void employee(AutoModel.Empleado empleado)
    {
      bool salir = false;
      do
      {
        WriteLine("\n\tBanco de Préstamos");
        WriteLine("1.Prestamos para aceptar");
        WriteLine("2.Calcular prestamos");
        WriteLine("3.Estatus del ultimo prestamo conocido por un usuario");
        WriteLine("4.Ver los ultimos 10 prestamos de un usario");
        WriteLine("5.Salir");
        Write("Ingrese una opción: ");
        string? opcion = ReadLine();

        if (opcion == null)
        {
          throw new Exception("Opción inválida");
        }

        switch (opcion)
        {
          case "1":
            verPrestamosParaAceptar(empleado);
            break;

          case "2":
            // calcularPrestamos(empleado);
            break;

          case "3":
            // verUltimoPrestamo(empleado);
            break;

          case "4":
            // verUltimosPrestamos(empleado);
            break;

          case "5":
            salir = true;
            break;
        }
      } while (!salir);
    }

    public static void verPrestamosParaAceptar(AutoModel.Empleado empleado)
    {
      try
      {
        using (var db = new AutoModel.bancoContext())
        {
          var prestamos = db.SolicitudPrestamos.Where(p => p.Estatus == 1).Join(db.Prestamos, pSolicitud => pSolicitud.PrestamoId, prestamo => prestamo.Id, (pSolicitud, prestamo) => new { pSolicitud, prestamo }).ToList();

          if (prestamos.Count == 0)
          {
            WriteLine("No hay prestamos para aceptar");
          }
          else
          {
            WriteLine("\nPrestamos para aceptar");
            foreach (var prestamo in prestamos)
            {
              WriteLine($"{prestamo.prestamo.Id} - {prestamo.prestamo.Cantidad}");
            }
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

  }
}