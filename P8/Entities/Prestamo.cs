public class Prestamo
{
  public uint interes;
  public float monto;
  public uint tiempo;
  private uint num_cuenta;

  public Prestamo(uint num_cuenta, uint interes, float monto, uint tiempo)
  {
    this.num_cuenta = num_cuenta;
    this.interes = interes;
    this.monto = monto;
    this.tiempo = tiempo;
  }

}