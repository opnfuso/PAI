using System;
using static System.Console;
using System.Collections.Generic;
namespace P6
{
  class Program
  {
    static void Main(string[] args)
    {
      string str = "alasalas";
      string[] res = palindromes(str);
      WriteLine(String.Join(" ", res));
    }

    static string[] palindromes(string str)
    {
      int len = str.Length;
      for (int i = 2; i < len; i++)
      {
        for (int j = 0; j <= len; j++)
        {
          string sub = "";
          for (int x = j; x < j + i; x++)
          {
            // sub += str[j];
          }
          // WriteLine(sub);
        }
      }

      string[] astr = { str };
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