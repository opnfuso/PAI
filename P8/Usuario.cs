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
  }

  public bool validateNip(uint nip)
  {
    if (nip == this.nip)
    { return true; }
    else
    { return false; }
  }
}