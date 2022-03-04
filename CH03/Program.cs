using System;
using static System.Console;

namespace CH03
{
    class Program
    {
        public static void Main(string[] args)
        {
            #region parse

            try
            {
                int age = int.Parse("30");
                DateTime birthday = DateTime.Parse("2 August 1991");
                WriteLine($"I was born {age} years ago");
                WriteLine($"My birthday is {birthday:D}");
            }
            catch (System.Exception ex)
            {
                WriteLine($"Not Valid format {ex}");
            }

            #endregion
            #region Try parse
            Write("How many students are here? : ");
            string? input = ReadLine();

            if (int.TryParse(input, out int num))
            {
                WriteLine($"There are {num} studens");
            }
            else
            {
                WriteLine("I couldn't parse");
            }
            #endregion
            #region Checked
            try
            {
                checked
                {
                    int x = int.MaxValue - 1;
                    WriteLine($"Inital value is : {x}");
                    x += 3;
                }
            }
            catch (OverflowException)
            {
                WriteLine("Overflow");
            }

            #endregion
        }
    }
}
