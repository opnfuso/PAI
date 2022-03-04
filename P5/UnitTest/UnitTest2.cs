using Xunit;
using Prestamo;

namespace UnitTest;

public class UnitTest2
{
  [Fact]
  public void ParseNotNumber()
  {
    string monto = "a";
    string tiempo = "6";
    string[] expected = { "No se pudo parsear" };
    Presta pres = new();

    string[] actual = pres.prestamo(monto, tiempo);

    Assert.Equal(expected, actual);
  }

  [Fact]
  public void SevenMonths()
  {
    string monto = "1000";
    string tiempo = "7";
    string[] expected = { "No se puede pagar en ese tiempo" };
    Presta pres = new();

    string[] actual = pres.prestamo(monto, tiempo);

    Assert.Equal(expected, actual);
  }

  [Fact]
  public void Borrow1000in6Months()
  {
    string monto = "1000";
    string tiempo = "6";
    string[] expected = { "El pago mensual es de 191.66667", "La fecha del primer pago es Sunday, April 3, 2022" };
    Presta pres = new();

    string[] actual = pres.prestamo(monto, tiempo);

    Assert.Equal(expected, actual);
  }
}