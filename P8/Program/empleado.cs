using System;
using static System.Console;
namespace P7
{
  public partial class Program
  {
    static void crear_empleado()
    {
      try
      {
        Write("\nIngresa el numero de empleado : ");
        string? nempleado = ReadLine();
        uint num_empleado = uint.Parse(nempleado);

        IEnumerable<Empleado> empleados_lista = Program.empleados.Where(empleado => empleado.num_empleado == num_empleado);
        if (empleados_lista.LongCount() != 0)
        {
          throw new Exception("Ese numero de empleado ya existe");
        }

        Write("\nIngresa el nombre : ");
        string? nombre = ReadLine();
        Write("Ingresa el apellido : ");
        string? apellido = ReadLine();
        Write("Ingresa el fecha de nacimiento : ");
        string? fecha = ReadLine();
        WriteLine();
        DateTime fecha_nacimiento = DateTime.Parse(fecha);
        Empleado worker = new Empleado(num_empleado, nombre, apellido, fecha_nacimiento);
        empleados.Add(worker);
        EmpleadoJsonSerialization(empleados);
        EmpleadoXmlSerialization(empleados);

        WriteLine("El empleado se ha creado satisfactoriamente");
      }
      catch (System.Exception error)
      {
        WriteLine(error.Message);
        return;
      }

    }
  }
}