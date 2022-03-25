public class Gerente
{
  public uint num_empleado;
  private string master_pass;

  public void setMasterPassword(string pass)
  {
    master_pass = pass;
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