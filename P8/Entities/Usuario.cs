using System.Xml.Serialization;
public class Usuario
{
  [XmlElement("num_cuenta")]
  public uint num_cuenta;
  [XmlElement("nombres")]
  public string nombres;
  [XmlElement("apellidos")]
  public string apellidos;
  [XmlElement("fecha_nacimiento")]
  public DateTime fecha_nacimiento;
  [XmlElement("num_empleado")]
  public uint nip;

  public Usuario()
  {

  }
  public Usuario(uint num_cuenta, string nombres, string apellidos, DateTime fecha_nacimiento, uint nip)
  {
    this.num_cuenta = num_cuenta;
    this.nombres = nombres;
    this.apellidos = apellidos;
    this.fecha_nacimiento = fecha_nacimiento;
    this.nip = nip;

    // saveToFile();
  }

  // public void saveToFile()
  // {
  //   string dir = Combine(CurrentDirectory, "Entities", "TextFiles");
  //   CreateDirectory(dir);

  //   string textFile = Combine(dir, "Usuarios.txt");

  //   if (File.Exists(textFile))
  //   {
  //     File.AppendAllText(textFile, $"{num_cuenta},{nombres},{apellidos},{fecha_nacimiento},{nip}\n");
  //   }
  //   else
  //   {
  //     File.WriteAllText(textFile, $"{num_cuenta},{nombres},{apellidos},{fecha_nacimiento},{nip}\n");
  //   }
  // }
}