using System;
using static System.Console;
using PeopleLibrary;
namespace CH07
{
  class Program
  {
    static void Main(string[] args)
    {
      #region 1erParcial
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
      #endregion

      System.Collections.Hashtable lookUpObject = new();
      lookUpObject.Add(key: 1, value: "Isaac");
      lookUpObject.Add(key: 2, value: "Isaac");
      lookUpObject.Add(key: 3, value: "Isaac");
      lookUpObject.Add(key: 4, value: "Isaac");
      lookUpObject.Add(key: 5, value: "Isaac");
      lookUpObject.Add(key: esmeralda, value: 2315);

      Person[] person = {
        new Person{FirstName = "Gabo"},
        new Person{FirstName = "Santos"},
        new Person{FirstName = "Danely"},
        new Person{FirstName = "Pau Pau"},
        new Person{FirstName = "Isaac"},
        new Person{FirstName = "Javier"},
        new Person{FirstName = "Esmeralda"},
        new Person{FirstName = "Yaramy"},
        new Person{FirstName = "Mario"},
        new Person{FirstName = "Alexis"},
      };

      foreach (var item in person)
      {
        WriteLine(item.FirstName);
      }

      Array.Sort(person);

      foreach (var item in person)
      {
        WriteLine(item.FirstName);
      }
    }
  }
}