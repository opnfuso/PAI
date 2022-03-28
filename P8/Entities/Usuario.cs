using static System.IO.Directory;
using static System.IO.Path;
using static System.Environment;
public class Usuario
{
  public uint num_cuenta;
  public string nombres;
  public string apellidos;
  public DateOnly fecha_nacimiento;
  private uint nip;

  public void setNip(uint nip)
  {
    this.nip = nip;

    saveToFile();
  }

  public bool validateNip(uint nip)
  {
    if (nip == this.nip)
    { return true; }
    else
    { return false; }
  }

  public Usuario(uint num_cuenta, string nombres, string apellidos, DateOnly fecha_nacimiento)
  {
    this.num_cuenta = num_cuenta;
    this.nombres = nombres;
    this.apellidos = apellidos;
    this.fecha_nacimiento = fecha_nacimiento;
  }

  public void saveToFile()
  {
    string dir = Combine(CurrentDirectory, "Entities", "TextFiles");
    CreateDirectory(dir);

    string textFile = Combine(dir, "Usuarios.txt");

    if (File.Exists(textFile))
    {
      File.AppendAllText(textFile, $"{num_cuenta},{nombres},{apellidos},{fecha_nacimiento},{nip}\n");
    }
    else
    {
      File.WriteAllText(textFile, $"{num_cuenta},{nombres},{apellidos},{fecha_nacimiento},{nip}\n");
    }
  }
}