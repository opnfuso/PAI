using System.Xml.Serialization;
public class Prestamo
{
  [XmlElement("interes")]
  public uint interes;
  [XmlElement("monto")]
  public float monto;
  [XmlElement("tiempo")]
  public uint tiempo;
  [XmlElement("num_cuenta")]
  public uint num_cuenta;
  [XmlElement("fecha_prestamo")]
  public DateTime fecha_prestamo;

  public Prestamo()
  {

  }

  public Prestamo(uint num_cuenta, uint interes, float monto, uint tiempo)
  {
    this.num_cuenta = num_cuenta;
    this.interes = interes;
    this.monto = monto;
    this.tiempo = tiempo;
    this.fecha_prestamo = DateTime.Now;

    // saveToFile();
  }

  // public void saveToFile()
  // {
  //   string dir = Combine(CurrentDirectory, "Entities", "TextFiles");
  //   CreateDirectory(dir);

  //   string textFile = Combine(dir, "Prestamos.txt");

  //   if (File.Exists(textFile))
  //   {
  //     File.AppendAllText(textFile, $"{num_cuenta},{interes},{monto},{tiempo},{fecha_prestamo}\n");
  //   }
  //   else
  //   {
  //     File.WriteAllText(textFile, $"{num_cuenta},{interes},{monto},{tiempo},{fecha_prestamo}\n");
  //   }
  // }

}