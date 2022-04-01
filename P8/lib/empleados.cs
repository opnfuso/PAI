using System;
using System.Xml.Serialization;
using static System.Environment;
using static System.IO.Path;
using static System.IO.Directory;

namespace P7
{
  public partial class Program
  {
    static List<Empleado> empleados = new List<Empleado>();

    private static void EmpleadoJsonSerialization(List<Empleado> empleados)
    {
      string dir = Combine(CurrentDirectory, "Entities", "JsonFiles");
      CreateDirectory(dir);

      string jsonPath = Combine(dir, "empleados.json");
      using (StreamWriter jsonStream = File.CreateText(jsonPath))
      {
        Newtonsoft.Json.JsonSerializer jss = new();
        jss.Serialize(jsonStream, empleados);
      }
    }

    private static void EmpleadoJsonDeserialization()
    {
      string dir = Combine(CurrentDirectory, "Entities", "JsonFiles");
      string jsonPath = Combine(dir, "empleados.json");

      if (File.Exists(jsonPath))
      {
        using (StreamReader jsonStream = File.OpenText(jsonPath))
        {
          Newtonsoft.Json.JsonSerializer jss = new();
          empleados = (List<Empleado>)jss.Deserialize(jsonStream, typeof(List<Empleado>));
        }
      }
      else
      {
        empleados = new List<Empleado>();
      }
    }

    private static void EmpleadoXmlSerialization(List<Empleado> empleados)
    {
      string dir = Combine(CurrentDirectory, "Entities", "XmlFiles");
      CreateDirectory(dir);

      string xmlPath = Combine(dir, "empleados.xml");
      using (StreamWriter xmlStream = File.CreateText(xmlPath))
      {
        XmlSerializer xss = new XmlSerializer(typeof(List<Empleado>));
        xss.Serialize(xmlStream, empleados);
      }
    }
  }
}