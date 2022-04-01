using System;
using static System.Console;
namespace P7
{
  public partial class Program
  {
    static void crear_gerente()
    {
      try
      {
        Write("\nIngresa el numero de gerente : ");
        string? ngerente = ReadLine();
        uint num_gerente = uint.Parse(ngerente);

        IEnumerable<Empleado> empleados = Program.empleados.Where(empleado => empleado.num_empleado == num_gerente);
        if (empleados.LongCount() != 0)
        {
          throw new Exception("Ese numero de empleado ya existe");
        }

        IEnumerable<Gerente> gerentes_lista = Program.gerentes.Where(gerenteq => gerenteq.num_empleado == num_gerente);
        if (gerentes_lista.LongCount() != 0)
        {
          throw new Exception("Ese numero de gerente ya existe");
        }

        Write("Ingresa la contraseña maestra : ");
        string? masterPass = ReadLine();
        WriteLine();
        Gerente gerente = new Gerente(num_gerente, masterPass);
        gerentes.Add(gerente);
        GerenteJsonSerialization(gerentes);
        GerenteXmlSerialization(gerentes);

        WriteLine("El gerente se ha creado satisfactoriamente");
      }
      catch (System.Exception error)
      {
        WriteLine(error.Message);
        return;
      }
    }
  }
}