using static System.IO.Directory;
using static System.IO.Path;
using static System.Environment;
public class Gerente
{
  public uint num_empleado;
  public string master_pass;

  public Gerente(uint num_empleado, string master_pass)
  {
    this.num_empleado = num_empleado;
    this.master_pass = master_pass;

    // saveToFile();
  }

  // void saveToFile()
  // {
  //   string dir = Combine(CurrentDirectory, "Entities", "TextFiles");
  //   CreateDirectory(dir);

  //   string textFile = Combine(dir, "Gerentes.txt");

  //   if (File.Exists(textFile))
  //   {
  //     File.AppendAllText(textFile, $"{num_empleado},{master_pass}\n");
  //   }
  //   else
  //   {
  //     File.WriteAllText(textFile, $"{num_empleado},{master_pass}\n");
  //   }
  // }

  public interface IGerente
  { }
}