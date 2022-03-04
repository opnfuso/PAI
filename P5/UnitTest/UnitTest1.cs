using Xunit;
using Cardinals;

namespace UnitTest;

public class UnitTest1
{
  [Fact]
  public void NotNumber()
  {
    string num = "a";
    string[] expected = { "No se puede parsear" };
    Cardinal car = new();

    string[] actual = car.runCardinals(num);

    Assert.Equal(expected, actual);
  }

  [Fact]
  public void NegativeNumber()
  {
    string num = "-1";
    string[] expected = { "No numeros negativos" };
    Cardinal car = new();

    string[] actual = car.runCardinals(num);

    Assert.Equal(expected, actual);
  }

  [Fact]
  public void Cardinal1()
  {
    string num = "1";
    string[] expected = { "1st" };
    Cardinal car = new();

    string[] actual = car.runCardinals(num);

    Assert.Equal(expected, actual);
  }

  [Fact]
  public void Cardinal1to11()
  {
    string num = "11";
    string[] expected = { "1st", "2nd", "3rd", "4th", "5th", "6th", "7th", "8th", "9th", "10th", "11th" };
    Cardinal car = new();

    string[] actual = car.runCardinals(num);

    Assert.Equal(expected, actual);
  }
}