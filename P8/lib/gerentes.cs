using System;
using System.Xml.Serialization;
using static System.Environment;
using static System.IO.Path;
using static System.IO.Directory;

namespace P7
{
  public partial class Program
  {
    static List<Gerente> gerentes = new List<Gerente>();

    private static void GerenteJsonSerialization(List<Gerente> gerentes)
    {
      string dir = Combine(CurrentDirectory, "Entities", "JsonFiles");
      CreateDirectory(dir);

      string jsonPath = Combine(dir, "gerentes.json");
      using (StreamWriter jsonStream = File.CreateText(jsonPath))
      {
        Newtonsoft.Json.JsonSerializer jss = new();
        jss.Serialize(jsonStream, gerentes);
      }
    }

    private static void GerenteJsonDeserialization()
    {
      string dir = Combine(CurrentDirectory, "Entities", "JsonFiles");
      string jsonPath = Combine(dir, "gerentes.json");

      if (File.Exists(jsonPath))
      {
        using (StreamReader jsonStream = File.OpenText(jsonPath))
        {
          Newtonsoft.Json.JsonSerializer jss = new();
          gerentes = (List<Gerente>)jss.Deserialize(jsonStream, typeof(List<Gerente>));
        }
      }
      else
      {
        gerentes = new List<Gerente>();
      }
    }

    private static void GerenteXmlSerialization(List<Gerente> gerentes)
    {
      string dir = Combine(CurrentDirectory, "Entities", "XmlFiles");
      CreateDirectory(dir);

      string xmlPath = Combine(dir, "gerentes.xml");
      using (StreamWriter xmlStream = File.CreateText(xmlPath))
      {
        XmlSerializer xs = new XmlSerializer(typeof(List<Gerente>));
        xs.Serialize(xmlStream, gerentes);
      }
    }
  }
}