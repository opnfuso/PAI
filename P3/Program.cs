using System;
using static System.Console;
namespace P3
{
  class Program
  {
    public static void Main(string[] args)
    {
      int rate = 15;

      try
      {
        Write("De cuanto quieres el prestamo? : ");
        string? input = ReadLine();
        float prestamo = float.Parse(input);
        WriteLine($"El prestamo va a ser de {prestamo}");

        WriteLine();
        Write("En cuantos meses quieres pagar (6m, 12m, 36m)? : ");
        input = ReadLine();
        int meses = int.Parse(input);

        if (meses != 6 && meses != 12 && meses != 36)
        {
          throw new Exception("No se puede pagar en ese tiempo");
        }

        WriteLine();
        WriteLine($"El interes es de {rate}%");

        float por_mes = (prestamo += (prestamo * (rate / 100f))) / meses;
        DateTime fecha = DateTime.Now;
        WriteLine($"El pago mensual es de {por_mes}");
        WriteLine($"La fecha del primer pago es {fecha.AddMonths(1):D}");
      }
      catch (FormatException)
      {
        WriteLine("No se pudo parsear");
        System.Environment.Exit(1);
      }
      catch (Exception ex)
      {
        WriteLine(ex.Message);
        System.Environment.Exit(1);
      }
    }
  }
}