using System;
using System.Text;
using static System.Console;
namespace P2
{
  class Program
  {
    public static void Main(string[] args)
    {
      var rand = new Random();
      byte[] bytes = new byte[128];
      rand.NextBytes(bytes);
      string str = Encoding.Default.GetString(bytes);
      var hexString = string.Join("",
                str.Select(c => String.Format("{0:X2}", Convert.ToInt32(c))));

      WriteLine("Byte Array is: ");
      WriteLine(String.Join(" ", bytes));
      WriteLine();
      WriteLine("The string is:");
      WriteLine(str);
      WriteLine();
      WriteLine("The hex string is:");
      WriteLine(hexString);
    }
  }
}