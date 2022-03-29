using System;
using static System.Console;
using System.Xml.Serialization;
using static System.Environment;
using static System.IO.Path;
namespace CH09
{
  class Program
  {
    static void Main(string[] args)
    {
      List<Person> people = new()
      {
        new(3000M)
        {
          FirstName = "Pau Pau",
          LastName = "El variables",
          DateOfBirth = new(1974, 3, 14)
        },
        new(4000M)
        {
          FirstName = "Andrik",
          LastName = "El casado",
          DateOfBirth = new(1990, 1, 10),
          Children = new()
          {
            new(0M)
            {
              FirstName = "Dylan",
              LastName = "Meneses",
              DateOfBirth = new(2022, 04, 28)
            }
          }
        },

        new(5000M)
        {
          FirstName = "Lizeth",
          LastName = "La que no se parece",
          DateOfBirth = new(1991, 2, 02)
        },

        new(10000000000M)
        {
          FirstName = "Alexis",
          LastName = "El crypto amigo",
          DateOfBirth = new(1991, 2, 02)
        }
      };

      // workingWithSerialization(people);
      JsonSerialization(people);
    }

    private static void JsonSerialization(List<Person> people)
    {
      string jsonPath = Combine(CurrentDirectory, "people.json");
      using (StreamWriter jsonStream = File.CreateText(jsonPath))
      {
        Newtonsoft.Json.JsonSerializer jss = new();
        jss.Serialize(jsonStream, people);
      }

      WriteLine("Written {0:N0} bytes of JSON to {1}", arg0: new FileInfo(jsonPath).Length, arg1: jsonPath);
    }

    private static void workingWithSerialization(List<Person> people)
    {
      XmlSerializer xs = new(people.GetType());

      string path = Combine(CurrentDirectory, "people.xml");

      using (FileStream stream = File.Create(path))
      {
        xs.Serialize(stream, people);
      }
      WriteLine("Written {0:N0} bytes of XML to {1}", arg0: new FileInfo(path).Length, arg1: path);
      WriteLine();
      WriteLine(File.ReadAllText(path));

      using (FileStream xmlLoad = File.Open(path, FileMode.Open))
      {
        List<Person>? loadedPeople = xs.Deserialize(xmlLoad) as List<Person>;
        if (loadedPeople is not null)
        {
          foreach (var p in loadedPeople)
          {
            WriteLine($"{p.FirstName} {p.LastName} has {p.Children?.Count ?? 0} children");
          }
        }
      }
    }
  }
}