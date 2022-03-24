using System;
using static System.Console;
namespace P7
{
  public partial class Program
  {
    static void crear_prestamo()
    {
      WriteLine();
      Write("\nIngresa el numero de cuenta : ");
      string? ncuenta = ReadLine();
      uint num_cuenta = uint.Parse(ncuenta);
      Write("\nIngresa el monto : ");
      string? monto = ReadLine();
      float monto_prestamo = float.Parse(monto);
      Write("\nIngresa el plazo : ");
      string? plazo = ReadLine();
      uint plazo_prestamo = UInt32.Parse(plazo);
      Write("\nIngresa el  interes : ");
      string? interes = ReadLine();
      uint int_interes = UInt32.Parse(interes);
      WriteLine();
      Prestamo prestamo = new Prestamo(num_cuenta, int_interes, monto_prestamo, plazo_prestamo);
      prestamos.Add(prestamo);
    }
  }
}