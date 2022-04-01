using System;
using System.Xml.Serialization;
using static System.Environment;
using static System.IO.Path;
using static System.IO.Directory;

namespace P7
{
  public partial class Program
  {
    static List<Usuario> usuarios = new List<Usuario>();

    private static void UsuarioJsonSerialization(List<Usuario> usuarios)
    {
      string dir = Combine(CurrentDirectory, "Entities", "JsonFiles");
      CreateDirectory(dir);

      string jsonPath = Combine(dir, "usuarios.json");
      using (StreamWriter jsonStream = File.CreateText(jsonPath))
      {
        Newtonsoft.Json.JsonSerializer jss = new();
        jss.Serialize(jsonStream, usuarios);
      }
    }

    private static void UsuarioJsonDeserialization()
    {
      string dir = Combine(CurrentDirectory, "Entities", "JsonFiles");
      string jsonPath = Combine(dir, "usuarios.json");

      if (File.Exists(jsonPath))
      {
        using (StreamReader jsonStream = File.OpenText(jsonPath))
        {
          Newtonsoft.Json.JsonSerializer jss = new();
          usuarios = (List<Usuario>)jss.Deserialize(jsonStream, typeof(List<Usuario>));
        }
      }
      else
      {
        usuarios = new List<Usuario>();
      }

    }

    private static void UsuarioXmlSerialization(List<Usuario> usuarios)
    {
      string dir = Combine(CurrentDirectory, "Entities", "XmlFiles");
      CreateDirectory(dir);

      string xmlPath = Combine(dir, "usuarios.xml");
      using (StreamWriter xmlStream = File.CreateText(xmlPath))
      {
        XmlSerializer xss = new XmlSerializer(typeof(List<Usuario>));
        xss.Serialize(xmlStream, usuarios);
      }
    }
  }
}