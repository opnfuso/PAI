using System;
using static System.Console;
namespace P4
{
  class Program
  {
    static void Main(string[] args)
    {
      Write("Ingresa un numero : ");
      string? res = ReadLine();

      runCardinals(res);
    }

    static void cardinals(int num)
    {

      if (num % 10 == 1 && num != 11)
      {
        WriteLine($"{num}st");
      }
      else if (num % 10 == 2)
      {
        WriteLine($"{num}nd");
      }
      else if (num % 10 == 3)
      {
        WriteLine($"{num}rd");
      }
      else if (num == 11)
      {
        WriteLine($"{num}th");
      }
      else
      {
        WriteLine($"{num}th");
      }
    }

    static void runCardinals(string num)
    {
      try
      {
        WriteLine("");
        int res = int.Parse(num);

        if (res < 0)
        {
          throw new Exception("No numeros negativos");
        }
        for (int i = 1; i <= res; i++)
        {
          cardinals(i);
        }
      }
      catch (FormatException)
      {
        WriteLine("No se puede parsear");
      }
      catch (Exception ex)
      {
        WriteLine(ex.Message);
      }

    }
  }
}