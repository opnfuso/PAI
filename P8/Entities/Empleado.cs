public class Empleado
{
  public uint num_empleado;
  public string nombres;
  public string apellidos;
  public DateOnly fecha_nacimiento;

  public Empleado(uint num_empleado, string nombres, string apellidos, DateOnly fecha_nacimiento)
  {
    this.num_empleado = num_empleado;
    this.nombres = nombres;
    this.apellidos = apellidos;
    this.fecha_nacimiento = fecha_nacimiento;
  }
}