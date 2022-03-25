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
  }

}