namespace Prestamo;
public class Presta
{
  public string[] prestamo(string monto, string tiempo)
  {
    int rate = 15;
    string[] res = new string[2];

    try
    {
      float prestamo = float.Parse(monto);

      int meses = int.Parse(tiempo);

      if (meses != 6 && meses != 12 && meses != 36)
      {
        throw new Exception("No se puede pagar en ese tiempo");
      }


      float por_mes = (prestamo += (prestamo * (rate / 100f))) / meses;
      DateTime fecha = DateTime.Parse("03/03/2022");
      res[0] = ($"El pago mensual es de {por_mes}");
      res[1] = ($"La fecha del primer pago es {fecha.AddMonths(1):D}");

      return res;
    }
    catch (FormatException)
    {
      string[] arr = { "No se pudo parsear" };
      return (arr);
    }
    catch (Exception ex)
    {
      string[] arr = { ex.Message };
      return (arr);
    }
  }
}
