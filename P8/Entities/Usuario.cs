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

  public Usuario(uint num_cuenta, string nombres, string apellidos, DateOnly fecha_nacimiento)
  {
    this.num_cuenta = num_cuenta;
    this.nombres = nombres;
    this.apellidos = apellidos;
    this.fecha_nacimiento = fecha_nacimiento;
  }
}