using System;
using static System.Console;
namespace P7
{
  public partial class Program
  {
    static void crear_empleado()
    {
      Write("\nIngresa el numero de empleado : ");
      string? nempleado = ReadLine();
      uint num_empleado = uint.Parse(nempleado);
      Write("\nIngresa el nombre : ");
      string? nombre = ReadLine();
      Write("Ingresa el apellido : ");
      string? apellido = ReadLine();
      Write("Ingresa el fecha de nacimiento : ");
      string? fecha = ReadLine();
      WriteLine();
      DateOnly fecha_nacimiento = DateOnly.Parse(fecha);
      Empleado worker = new Empleado(num_empleado, nombre, apellido, fecha_nacimiento);
      empleados.Add(worker);

      WriteLine("El empleado se ha creado satisfactoriamente");
    }
  }
}