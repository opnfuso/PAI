using System;
using static System.Console;
namespace P7
{
  public partial class Program
  {
    static void crear_prestamo(uint num_cuenta)
    {
      Write("Ingresa el monto : ");
      string? monto = ReadLine();
      float monto_prestamo = float.Parse(monto);
      Write("Ingresa el plazo (6, 12, 24, 36 meses) : ");
      string? plazo = ReadLine();
      uint plazo_prestamo = uint.Parse(plazo);
      if (plazo_prestamo != 6 && plazo_prestamo != 12 && plazo_prestamo != 24 && plazo_prestamo != 36)
      {
        WriteLine("No se puede pagar en ese tiempo");
        return;
      }

      bool approved = validar_prestamos(plazo_prestamo);

      if (!approved)
      {
        WriteLine("El prestamo no pudo ser aprobado");
        return;
      }

      WriteLine("El interes es de 15%");
      uint int_interes = 15;
      WriteLine();

      float monto_total = monto_prestamo + (monto_prestamo * (int_interes / 100f));

      float por_mes = monto_total / plazo_prestamo;
      DateTime fecha = DateTime.Now;
      WriteLine($"El pago mensual es de {por_mes}");
      WriteLine($"La fecha del primer pago es {fecha.AddMonths(1):D}");


      Prestamo prestamo = new Prestamo(num_cuenta, int_interes, monto_prestamo, plazo_prestamo);
      prestamos.Add(prestamo);


      WriteLine("El prestamo se ha generado satisfactoriamente");
    }

    static void mis_prestamos(uint num_cuenta)
    {
      IEnumerable<Prestamo> prestamos = Program.prestamos.Where(prestamo => prestamo.num_cuenta == num_cuenta);
      if (prestamos.LongCount() == 0)
      {
        WriteLine("No tienes prestamos");
        return;
      }

      WriteLine("\nMonto\t\tPlazo\tInteres\tFecha de creacion");
      foreach (Prestamo prestamo in prestamos)
      {
        WriteLine($"{prestamo.monto}\t\t{prestamo.tiempo}\t{prestamo.interes}\t{prestamo.fecha_prestamo}");
      }
    }

    static bool validar_prestamos(uint plazo)
    {
      if (plazo == 6 || plazo == 12)
      {
        Write("Ingresa numero de empleado : ");
        string? res = ReadLine();
        uint num_empleado = uint.Parse(res);
        IEnumerable<Empleado> workers = empleados.Where(empleado => empleado.num_empleado == num_empleado);

        if (workers.LongCount() == 0)
        {
          WriteLine("No existe el empleado");
          return false;
        }

        WriteLine("Aprovado");
        return true;
      }
      else if (plazo == 24 || plazo == 36)
      {
        Write("Ingresa numero de empleado del gerente : ");
        string? res = ReadLine();
        uint num_empleado = uint.Parse(res);
        IEnumerable<Gerente> managers = gerentes.Where(gerente => gerente.num_empleado == num_empleado);

        if (managers.LongCount() == 0)
        {
          WriteLine("No existe el gerente");
          return false;
        }

        Write("Ingresa la contraseña maestra");
        res = ReadLine();

        bool pass = managers.ElementAt(0).validateMasterPassword(res);

        if (!pass)
        {
          WriteLine("La contraseña maestra es incorrecta");
          return false;
        }

        WriteLine("Aprovado");
        return true;
      }
      else
      {
        return false;
      }
    }
  }
}