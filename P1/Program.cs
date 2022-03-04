using System;
using static System.Console;

namespace P1
{
    class Program
    {
        public static void Main(string[] args)
        {
            WriteLine($"Type\t{"Byte(s)"}{"Min", 26}{"Max", 32}");
            WriteLine($"sbyte\t{sizeof(sbyte)}{sbyte.MinValue,32}{sbyte.MaxValue,32}");
            WriteLine($"short\t{sizeof(byte)}{byte.MinValue,32}{byte.MaxValue,32}");
            WriteLine($"ushort\t{sizeof(ushort)}{ushort.MinValue,32}{ushort.MaxValue,32}");
            WriteLine($"int\t{sizeof(int)}{int.MinValue,32}{int.MaxValue,32}");
            WriteLine($"long\t{sizeof(long)}{long.MinValue,32}{long.MaxValue,32}");
            WriteLine($"ulong\t{sizeof(ulong)}{ulong.MinValue,32}{ulong.MaxValue,32}");
            WriteLine($"float\t{sizeof(float)}{float.MinValue,32}{float.MaxValue,32}");
            WriteLine($"double\t{sizeof(double)}{double.MinValue,32}{double.MaxValue,32}");
            WriteLine($"decimal\t{sizeof(decimal)}{decimal.MinValue,31}{decimal.MaxValue,32}");
        }
    }
}