using System;
using static System.Console;
namespace P6
{
  class Program
  {
    static void Main(string[] args)
    {
      Write("Ingresa una palabra : ");
      string? str = ReadLine();
      string[] res = palindromes(str);
      WriteLine();
      WriteLine("Palindromas : ");
      WriteLine(String.Join(" ", res));
    }

    static string[] palindromes(string str)
    {
      int len = str.Length;
      string[] astr = { };
      List<string> astrList = new List<string>();
      for (int i = 2; i <= len; i++)
      {
        for (int j = 0; j <= len - i; j++)
        {
          string sub = "";
          for (int x = j; x < j + i; x++)
          {
            sub += str[x];
          }
          if (isPalindrome(sub) && !astrList.Contains(sub))
          {
            astrList.Add(sub);
          }
        }
      }
      astr = astrList.ToArray();
      return astr;
    }

    static bool isPalindrome(string myString)
    {
      string first = myString.Substring(0, myString.Length / 2);
      char[] arr = myString.ToCharArray();

      Array.Reverse(arr);

      string temp = new string(arr);
      string second = temp.Substring(0, temp.Length / 2);

      return first.Equals(second);
    }
  }
}