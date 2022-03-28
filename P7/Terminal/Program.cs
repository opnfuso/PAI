using System;
using static System.Console;
using P7;
namespace Terminal
{
  class Program
  {
    public static void Main(string[] args)
    {
      var arr = new int[,] { { 1, 2, 3 }, { 4, 5, 6 } };
      var arr2 = new double[,] { { 1.1 }, { 1.2 } };
      var arr2d = new Array2D<double>(arr2);
      // foreach (var item in arr2d)
      // {
      //   WriteLine(item);
      // }
      WriteLine(arr2d.ElementAt(0, 0));
    }
  }
}