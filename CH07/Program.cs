using System;
using static System.Console;
using PeopleLibrary;
namespace CH07
{
  class Program
  {
    static void Main(string[] args)
    {
      var esmeralda = new Person();
      esmeralda.FirstName = "Esmeralda";
      esmeralda.DateOfBirth = DateTime.Parse("1990 04 02");
      esmeralda.vaccine = VaccineApplied.AstraZeneca;
      esmeralda.Children.Add(new Person
      {
        FirstName = "Jose",
        DateOfBirth = DateTime.Now
      });

      for (var childrenIndex = 0; childrenIndex < esmeralda.Children.Count; childrenIndex++)
      {
        WriteLine(esmeralda.Children[childrenIndex].FirstName);
      }

      var fruit = esmeralda.GetFruit();

      WriteLine($"There are: {fruit.Item2} {fruit.Item1}");

    }
  }
}