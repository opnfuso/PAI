using static System.IO.Directory;
using static System.IO.Path;
using static System.Environment;
public class Gerente
{
  public uint num_empleado;
  private string master_pass;

  public void setMasterPassword(string pass)
  {
    master_pass = pass;

    saveToFile();
  }

  void saveToFile()
  {
    string dir = Combine(CurrentDirectory, "Entities", "TextFiles");
    CreateDirectory(dir);

    string textFile = Combine(dir, "Gerentes.txt");

    if (File.Exists(textFile))
    {
      File.AppendAllText(textFile, $"{num_empleado},{master_pass}\n");
    }
    else
    {
      File.WriteAllText(textFile, $"{num_empleado},{master_pass}\n");
    }
  }

  public bool validateMasterPassword(string pass)
  {
    if (pass == master_pass)
    { return true; }
    else
    { return false; }
  }

  public Gerente(uint num_empleado)
  {
    this.num_empleado = num_empleado;
  }

  public interface IGerente
  { }
}