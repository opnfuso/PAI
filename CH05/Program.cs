using System;
using static System.Console;
namespace CH05
{
  class Program
  {
    static void Main(string[] args)
    {
      RunTimesTable();
    }

    //Lambda =>
    //F#
    static int fibbonaci(int number) =>
    //Simplified switch
    number switch
    {
      1 => 0,
      2 => 1,
      //_ default null
      _ => fibbonaci(number - 1) + fibbonaci(number - 2)
    };

    //DRY Don't Repeat Yourself
    //KISS Keep It Stupid Simple
    //0 255
    /// <summary>
    /// Ges a byte number, and proccess the timetable if number
    /// </summary>
    /// <param name="number">byte type, only from 0 to 255</param>
    static void TimesTable(byte number)
    {
      for (var row = 0; row <= number; row++)
      {
        WriteLine($"{row} x {number} = {row * number}");
      }

    }

    static void RunTimesTable()
    {
      byte number = 0;
      bool isNumber = false;
      do
      {
        Write("Give me a number 0-255");
        isNumber = byte.TryParse(ReadLine(), out number);
      } while (!isNumber);
      TimesTable(number);
    }
  }
}