using System;
using static System.Console;
namespace E2
{
  class Program
  {
    public static void Main(string[] args)
    {
      console();
    }

    public static bool IsClose(string str)
    {
      // Return false if the string is null or empty
      if (string.IsNullOrEmpty(str))
      {
        return false;
      }

      // Return true if  (, [, or { are closed in the string
      var hashmap = new Dictionary<char, int>();

      hashmap.Add('(', 0);
      hashmap.Add('[', 0);
      hashmap.Add('{', 0);

      foreach (var c in str)
      {
        switch (c)
        {
          case '(':
            hashmap['(']++;
            break;

          case '[':
            hashmap['[']++;
            break;

          case '{':
            hashmap['{']++;
            break;

          case ')':
            hashmap['(']--;
            break;

          case ']':
            hashmap['[']--;
            break;

          case '}':
            hashmap['{']--;
            break;
        }
      }

      return hashmap['('] == 0 && hashmap['['] == 0 && hashmap['{'] == 0;
    }

    public static void console()
    {
      Write("Introduzca el string: ");
      string str = ReadLine();

      bool ban = IsClose(str);
      WriteLine(ban);
    }
  }
}