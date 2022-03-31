using static System.IO.Directory;
using static System.IO.Path;
using static System.Environment;
public class Prestamo
{
  public uint interes;
  public float monto;
  public uint tiempo;
  public uint num_cuenta;

  public DateTime fecha_prestamo;

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