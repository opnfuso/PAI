using Xunit;
using CalculatorLib;

namespace CalculatorProject;

public class UnitTest1
{
  [Fact]
  public void Test2And2()
  {
    // arrange
    double a = 2;
    double b = 2;
    double expected = 4;
    Calculator calc = new();

    // act
    double actual = calc.Add(a, b);

    // Assert
    Assert.Equal(expected, actual);
  }

  [Fact]

  public void Test3And2()
  {
    double a = 3;
    double b = 2;
    double expected = 5;
    Calculator calc = new();

    double actual = calc.Add(a, b);

    Assert.Equal(expected, actual);
  }
}