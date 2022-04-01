using System.Xml.Serialization;
public class Empleado
{
  [XmlElement("num_empleado")]
  public uint num_empleado;
  [XmlElement("nombres")]
  public string nombres;
  [XmlElement("apellidos")]
  public string apellidos;
  [XmlElement("fecha_nacimiento")]
  public DateTime fecha_nacimiento;

  public Empleado()
  {

  }

  public Empleado(uint num_empleado, string nombres, string apellidos, DateTime fecha_nacimiento)
  {
    this.num_empleado = num_empleado;
    this.nombres = nombres;
    this.apellidos = apellidos;
    this.fecha_nacimiento = fecha_nacimiento;

    //saveToFile();
  }

  // void saveToFile()
  // {
  //   string dir = Combine(CurrentDirectory, "Entities", "TextFiles");
  //   CreateDirectory(dir);

  //   string textFile = Combine(dir, "Empleados.txt");

  //   if (File.Exists(textFile))
  //   {
  //     File.AppendAllText(textFile, $"{num_empleado},{nombres},{apellidos},{fecha_nacimiento}\n");
  //   }
  //   else
  //   {
  //     File.WriteAllText(textFile, $"{num_empleado},{nombres},{apellidos},{fecha_nacimiento}\n");
  //   }
  // }

  public interface IEmpleado
  { }
}