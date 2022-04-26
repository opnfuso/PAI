using System;
using static System.Console;

namespace P9
{
  partial class Program
  {
    public static void employee(AutoModel.Empleado empleado)
    {
      bool salir = false;
      do
      {
        WriteLine("\n\tBanco de Préstamos");
        WriteLine("1.Prestamos para aceptar");
        WriteLine("2.Calcular prestamos");
        WriteLine("3.Estatus del ultimo prestamo conocido por un usuario");
        WriteLine("4.Ver los ultimos 10 prestamos de un usario");
        WriteLine("5.Prestamos aceptados");
        WriteLine("6.Salir");
        Write("Ingrese una opción: ");
        string? opcion = ReadLine();

        if (opcion == null)
        {
          throw new Exception("Opción inválida");
        }

        switch (opcion)
        {
          case "1":
            verPrestamosParaAceptar(empleado);
            break;

          case "2":
            calcularPrestamos(empleado);
            break;

          case "3":
            verUltimoPrestamo(empleado);
            break;

          case "4":
            verUltimosPrestamos(empleado);
            break;

          case "5":
            verPrestamosAceptados(empleado);
            break;

          case "6":
            salir = true;
            break;
        }
      } while (!salir);
    }

    public static void verPrestamosParaAceptar(AutoModel.Empleado empleado)
    {
      using (var db = new AutoModel.bancoContext())
      {
        var query = db.SolicitudPrestamos.Where(p => p.Estatus == 1).Join(db.Prestamos, pSolicitud => pSolicitud.PrestamoId, prestamo => prestamo.Id, (pSolicitud, prestamo) => new { pSolicitud, prestamo }).ToList();

        if (query.Count == 0)
        {
          WriteLine("No hay prestamos para aceptar");
        }
        else
        {
          WriteLine("\nPrestamos para aceptar");
          int i = 0;
          foreach (var item in query)
          {
            var usuario = db.Usuarios.Where(u => u.Id == item.prestamo.UsuarioId).FirstOrDefault();

            if (usuario is null)
            {
              throw new Exception("No se encontró el usuario");
            }

            var persona = db.Personas.Where(p => p.Id == usuario.PersonaId).FirstOrDefault();

            if (persona is null)
            {
              throw new Exception("No se encontraron los datos de la persona");
            }

            WriteLine($"{i + 1} - {item.prestamo.Cantidad}$ solicitado el {item.prestamo.FechaSolicitud} por {persona.PrimerNombre} {persona.PrimerApellido}");
            i++;
          }

          Write("\nIngrese el número de la solicitud: ");
          string? opcion = ReadLine();

          if (opcion == null)
          {
            throw new Exception("Opción inválida");
          }

          int id = query.ElementAt(int.Parse(opcion) - 1).prestamo.Id;
          int sid = query.ElementAt(int.Parse(opcion) - 1).pSolicitud.Id;
          long uid = query.ElementAt(int.Parse(opcion) - 1).prestamo.UsuarioId;
          decimal cantidad = query.ElementAt(int.Parse(opcion) - 1).prestamo.Cantidad;
          WriteLine($"\nPrestamo {id}$ por la cantidad de {cantidad}$");
          WriteLine("1.Aceptar");
          WriteLine("2.Denegar");
          Write("Ingrese una opción: ");
          opcion = ReadLine();

          if (opcion == null)
          {
            throw new Exception("Opción inválida");
          }

          switch (opcion)
          {
            case "1":
              var rEmpleado = empleado.AceptarPrestamo(id, sid, uid);
              if (rEmpleado is Exception)
              {
                throw (Exception)rEmpleado;
              }

              if (rEmpleado is AutoModel.Empleado)
              {
                WriteLine("Prestamo aceptado");
              }
              break;

            case "2":
              var rSolicitud = empleado.DenegarPrestamo(sid);
              if (rSolicitud is Exception)
              {
                throw (Exception)rSolicitud;
              }

              if (rSolicitud is AutoModel.SolicitudPrestamo)
              {
                WriteLine("Prestamo denegado");
              }
              break;

            default:
              throw new Exception("Opción inválida");
          }
        }
      }
    }

    public static void calcularPrestamos(AutoModel.Empleado empleado)
    {
      WriteLine("\nCalcular prestamos");
      Write("Ingrese la cantidad de dinero a solicitar: ");
      string? cantidad = ReadLine();
      Write("Ingrese la cantidad de cuotas: ");
      string? cuotas = ReadLine();

      if (cantidad == null || cuotas == null)
      {
        throw new Exception("Opción inválida");
      }

      decimal cantidadDecimal = decimal.Parse(cantidad);
      int cuotasInt = int.Parse(cuotas);

      switch (cuotasInt)
      {
        case 6:
          decimal total = ((cantidadDecimal * 0.12m) + cantidadDecimal);
          decimal cuota = total / 6;
          WriteLine($"\nEl total a pagar es de {total}$ y la cuota mensual es de {cuota}$");
          break;

        case 12:
          total = ((cantidadDecimal * 0.18m) + cantidadDecimal);
          cuota = total / 12;
          WriteLine($"\nEl total a pagar es de {total}$ y la cuota mensual es de {cuota}$");
          break;

        case 24:
          total = ((cantidadDecimal * 0.279m) + cantidadDecimal);
          cuota = total / 24;
          WriteLine($"\nEl total a pagar es de {total}$ y la cuota mensual es de {cuota}$");
          break;

        case 36:
          total = ((cantidadDecimal * 0.42m) + cantidadDecimal);
          cuota = total / 36;
          WriteLine($"\nEl total a pagar es de {total}$ y la cuota mensual es de {cuota}$");
          break;
        default:
          throw new Exception("Cuotas inválidas");
      }

    }

    public static void verUltimoPrestamo(AutoModel.Empleado empleado)
    {
      using (var db = new AutoModel.bancoContext())
      {
        Write("\nIngrese el id del usuario: ");
        string? id = ReadLine();

        if (id == null)
        {
          throw new Exception("Opción inválida");
        }

        int idInt = int.Parse(id);
        var prestamo = empleado.UltimoPrestamo(idInt);

        if (prestamo is Exception)
        {
          throw (Exception)prestamo;
        }

        if (prestamo is AutoModel.Prestamo)
        {
          var presta = (AutoModel.Prestamo)prestamo;
          var solicitud = db.SolicitudPrestamos.Where(p => p.PrestamoId == presta.Id).FirstOrDefault();
          WriteLine("\nUltimo prestamo");
          WriteLine($"Monto: {presta.Cantidad}$");

          switch (solicitud.Estatus)
          {
            case 1:
              WriteLine("Estatus: Solicitado");
              break;

            case 2:
              WriteLine("Estatus: Aceptado");
              break;

            case 3:
              WriteLine("Estatus: Denegado");
              break;

            default:
              throw new Exception("Estatus inválido");
          }

        }
      }
    }

    public static void verUltimosPrestamos(AutoModel.Empleado empleado)
    {
      using (var db = new AutoModel.bancoContext())
      {
        Write("\nIngrese el id del usuario: ");
        string? id = ReadLine();

        if (id == null)
        {
          throw new Exception("Opción inválida");
        }

        int idInt = int.Parse(id);

        var prestamos = empleado.UltimosPrestamos(idInt);

        if (prestamos is Exception)
        {
          throw (Exception)prestamos;
        }

        if (prestamos is List<AutoModel.Prestamo>)
        {
          int i = 1;
          var presta = (List<AutoModel.Prestamo>)prestamos;
          WriteLine("\nUltimos prestamos");
          foreach (var item in presta)
          {
            WriteLine($"{i}.- Monto: {item.Cantidad}$ Fecha de solicitud: {item.FechaSolicitud} Meses: {item.Meses}");
            i++;
          }
        }
      }
    }

    public static void verPrestamosAceptados(AutoModel.Empleado empleado)
    {
      using (var db = new AutoModel.bancoContext())
      {
        int idInt = empleado.Id;

        var prestamos = empleado.PrestamosAceptados(idInt);

        if (prestamos is Exception)
        {
          throw (Exception)prestamos;
        }

        if (prestamos is List<AutoModel.Prestamo>)
        {
          int i = 1;
          var presta = (List<AutoModel.Prestamo>)prestamos;
          WriteLine("\nPrestamos aceptados");
          foreach (var item in presta)
          {
            WriteLine($"{i}.- Monto: {item.Cantidad}$ Fecha de aprobación: {item.FechaAprobacion} Meses: {item.Meses}");
            i++;
          }
        }
      }
    }
  }
}
