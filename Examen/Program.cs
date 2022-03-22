using System;
using static System.Console;
namespace Examen
{
  class Program
  {
    static void Main(string[] args)
    {
      Write("Ingrese un numero : ");
      int ans = int.Parse(ReadLine());
      int[] res = toZero(ans);
      WriteLine(String.Join(",", res));
    }
    static int[] toZero(int num)
    {
      List<int> ares = new List<int>();
      int res = 0;
      for (int i = 1; i <= num - 1; i++)
      {
        ares.Add(i);
        res += i;
      }
      ares.Add(res * -1);
      int[] respuesta = ares.ToArray();
      return respuesta;
    }
  }
}