using System;
using static System.Console;

namespace P9
{
  partial class Program
  {
    public static void manager(AutoModel.Gerente gerente)
    {
      bool salir = false;
      do
      {
        WriteLine("\n\tBanco de Préstamos");
        WriteLine("1.Generar empleado");
        WriteLine("2.Pedir vacaciones");
        WriteLine("3.Aceptar prestamos");
        WriteLine("4.Generar reportes");
        WriteLine("5.Dar de baja empleados");
        WriteLine("6.Dar de baja usuarios");
        WriteLine("7.Pausar prestamos");
        WriteLine("8.Pedir un prestamo");
        WriteLine("9.Aprobar solicitudes de usuarios");
        WriteLine("10.Salir");
        Write("Ingrese una opción: ");
        string? opcion = ReadLine();

        if (opcion == null)
        {
          throw new Exception("Opción inválida");
        }

        switch (opcion)
        {
          case "1":
            generarEmpleado(gerente);
            break;

          case "2":
            // pedirVacaciones(gerente);
            break;

          case "3":
            // aceptarPrestamosGerente(gerente);
            break;

          case "4":
            // generarReportes(gerente);
            break;

          case "5":
            // bajaEmpleados(gerente);
            break;

          case "6":
            // bajaUsuarios(gerente);
            break;

          case "7":
            // pausarPrestamos(gerente);
            break;

          case "8":
            // pedirPrestamoGerente(gerente);
            break;

          case "9":
            // aceptarUsuarios(gerente);
            break;

          case "10":
            salir = true;
            break;

          default:
            throw new Exception("Opción inválida");
        }
      } while (!salir);
    }
    public static void generarEmpleado(AutoModel.Gerente gerente)
    {
      using (AutoModel.bancoContext db = new())
      {
        var empleado = new AutoModel.Empleado();
        Write("Ingrese el primer Nombre");
        string? Pn = ReadLine();
        WriteLine("Ingrese el Segundo Nombre (Puede ser nulo)");
        string? Sn = ReadLine();
        WriteLine("Ingrese el Primer Apellido");
        string? Pa = ReadLine();
        WriteLine("Ingrese el Segundo Apellido");
        string? Sa = ReadLine();
        WriteLine("Ingrese la Fecha de Nacimiento yyyy-mm-dd");
        string? nacimiento = ReadLine();
        DateOnly fechaN = DateOnly.Parse(nacimiento);
        WriteLine("Ingrese la contraseña");
        string? pass = ReadLine();

        var nEmpleado = empleado.Create(Pn, Sn, Pa, Sa, fechaN, pass);

        if (nEmpleado is Exception)
        {
          throw new Exception("Error al crear al empleado");
        }

        var cuenta = new AutoModel.Cuenta();
        cuenta.NCuentaEmpleado = empleado.Id;
        cuenta.Tipo = 2;
        db.Cuentas.Add(cuenta);
        db.SaveChanges();

        WriteLine("Empleado creado con exito");
      }
    }
  }
}