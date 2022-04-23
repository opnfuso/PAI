using System;
using static System.Console;

namespace P9
{
  partial class Program
  {
    public static void user(AutoModel.Usuario usuario)
    {
      bool salir = false;
      do
      {
        try
        {
          WriteLine("\n\tBanco de Préstamos");
          WriteLine($"Saldo: ${usuario.Saldo}");
          WriteLine("1.Pedir préstamo");
          WriteLine("2.Ver historial de pagos");
          WriteLine("3.Ver préstamo activo");
          WriteLine("4.Salir");
          Write("Ingrese una opción: ");
          string? opcion = ReadLine();

          if (opcion == null)
          {
            throw new Exception("Opción inválida");
          }

          switch (opcion)
          {
            case "1":
              // pedirPrestamo(usuario);
              break;
            case "2":
              // verHistorial(usuario);
              break;
            case "3":
              verPrestamoActivo(usuario);
              break;

            case "4":
              salir = true;
              break;
            default:
              throw new Exception("Opción inválida");
          }
        }
        catch (System.Exception ex)
        {
          WriteLine("\nError: " + ex.Message);
          Write("Presione una tecla para continuar...");
          Read();
        }
      } while (!salir);
    }

    public static void verPrestamoActivo(AutoModel.Usuario usuario)
    {
      try
      {
        var Prestamo = new AutoModel.Prestamo();
        var prestamo = usuario.verPrestamoActivo(usuario);

        if (prestamo is Exception)
        {
          throw (Exception)prestamo;
        }

        if (prestamo is AutoModel.Prestamo)
        {
          WriteLine("\nPréstamo activo");
          WriteLine($"Monto: ${((AutoModel.Prestamo)prestamo).Cantidad}");
          WriteLine($"Fecha de inicio: {((AutoModel.Prestamo)prestamo).FechaSolicitud}");
          WriteLine($"Fecha de vencimiento: {((AutoModel.Prestamo)prestamo).FechaLiquidacion}");
          WriteLine($"Tasa: {((AutoModel.Prestamo)prestamo).Interes} %");
          WriteLine($"Plazo: {((AutoModel.Prestamo)prestamo).Meses}");
          WriteLine($"Pago por mes: {((AutoModel.Prestamo)prestamo).PagoMes}");
          WriteLine($"Estado: {((AutoModel.Prestamo)prestamo).Activo}");
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