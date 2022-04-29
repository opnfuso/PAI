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
        WriteLine("1.Añadir empleado");
        WriteLine("2.Pedir vacaciones");
        WriteLine("3.Aceptar prestamos");
        WriteLine("4.Generar reportes");
        WriteLine("5.Dar de baja empleados");
        WriteLine("6.Dar de baja usuarios");
        WriteLine("7.Pausar prestamos");
        WriteLine("8.Pedir un prestamo");
        WriteLine("9.Aprobar solicitudes de usuarios");
        WriteLine("10.Añadir gerente");
        WriteLine("11.Salir");
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
            aceptarPrestamosGerente(gerente);
            break;

          case "4":
            // generarReportes(gerente);
            break;

          case "5":
            bajaEmpleados(gerente);
            break;

          case "6":
            // bajaUsuarios(gerente);
            break;

          case "7":
            // pausarPrestamos(gerente);
            break;

          case "8":
            pedirPrestamoGerente(gerente);
            break;

          case "9":
            aceptarUsuarios(gerente);
            break;

          case "10":
            addGerente(gerente);
            break;

          case "11":
            salir = true;
            break;

          default:
            throw new Exception("Opción inválida");
        }
      } while (!salir);
    }
    public static void generarEmpleado(AutoModel.Gerente gerente)
    {
      var empleado = new AutoModel.Empleado();
      Write("Ingrese el primer Nombre : ");
      string? Pn = ReadLine();
      Write("Ingrese el Segundo Nombre (Puede ser nulo) : ");
      string? Sn = ReadLine();
      Write("Ingrese el Primer Apellido : ");
      string? Pa = ReadLine();
      Write("Ingrese el Segundo Apellido : ");
      string? Sa = ReadLine();
      Write("Ingrese la Fecha de Nacimiento yyyy-mm-dd : ");
      string? nacimiento = ReadLine();
      DateOnly fechaN = DateOnly.Parse(nacimiento);
      Write("Ingrese la contraseña : ");
      string? pass = ReadLine();

      var nEmpleado = empleado.Create(Pn, Sn, Pa, Sa, fechaN, pass);

      if (nEmpleado is Exception)
      {
        throw new Exception("Error al crear al empleado");
      }

      WriteLine("Empleado creado con exito");
    }

    public static void addGerente(AutoModel.Gerente gerente)
    {
      {
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

        var nGerente = gerente.Create(Pn, Sn, Pa, Sa, pass, fechaN);

        if (nGerente is Exception)
        {
          throw new Exception("Error al crear al gerente");
        }

        WriteLine("Gerente creado con exito");
      }
    }

    public static void aceptarPrestamosGerente(AutoModel.Gerente gerente)
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
              var rEmpleado = gerente.AceptarPrestamo(id, sid, uid);
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
              var rSolicitud = gerente.DenegarPrestamo(sid);
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

    public static void pedirPrestamoGerente(AutoModel.Gerente gerente)
    {
      Write("Ingrese la cantidad del préstamo");
      string? cantidad = ReadLine();
      decimal c = decimal.Parse(cantidad);
      Write("Ingrese la cantidad de cuotas");
      string? cuotas = ReadLine();

      var rGerente = gerente.CrearPrestamo(gerente.Id, c, int.Parse(cuotas));

      if (rGerente is Exception)
      {
        throw new Exception("Error al crear el prestamo");
      }

      WriteLine("Prestamo creado con exito");
    }

    public static void bajaEmpleados(AutoModel.Gerente gerente)
    {
      Write("Ingrese el id del empleado a dar de baja : ");
      string? id = ReadLine();
      var rGerente = gerente.BajaEmpleado(int.Parse(id));

      if (rGerente is Exception)
      {
        throw new Exception("Error al dar de baja al empleado");
      }

      WriteLine("Empleado dado de baja con exito");
    }

    public static void aceptarUsuarios(AutoModel.Gerente gerente)
    {

      using (AutoModel.bancoContext db = new())
      {
        var query = db.Solicituds.Where(p => p.Estatus == 1).Join
        (
            db.Personas, pSolicitud => pSolicitud.PersonaId, persona => persona.Id, (pSolicitud, persona) => new { pSolicitud, persona }
        ).ToList();
        WriteLine("Solicitudes:");
        if (query.Count is 0)
        {
          throw new Exception("No Hay Solicitudes Pendientes...");
        }
        else
        {
          foreach (var item in query)
          {
            WriteLine($"Id de la persona: {item.persona.Id} [{item.persona.PrimerNombre} {item.persona.SegundoNombre} {item.persona.PrimerApellido} {item.persona.SegundoApellido}]");
          }
          WriteLine("----------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
          Write("ID Persona:");
          int id = int.Parse(ReadLine());
          var person = db.Solicituds.Where(u => u.PersonaId == id).FirstOrDefault();
          if (person.Estatus != 1 || person is null)
          {
            throw new Exception("Error:Solicitud no encontrada");
          }
          else
          {
            WriteLine("1-Aprobar\n2-Rechazar");
            int status = int.Parse(ReadLine());
            switch (status)
            {
              case 1:
                {
                  person.Estatus = 2;
                  WriteLine("Aprobado!");

                  var datos = db.Solicituds.Where(p => p.PersonaId == id).Join(
                      db.Personas, pSolicitud => pSolicitud.PersonaId, persona => persona.Id, (pSolicitud, persona) => new { pSolicitud, persona }
                  ).FirstOrDefault();


                  db.SaveChanges();

                  var user = new AutoModel.Usuario();
                  var rUser = user.Create(id, datos.persona.PrimerNombre, datos.persona.PrimerApellido, datos.persona.SegundoApellido, datos.persona.FechaNacimiento);
                  if (rUser is Exception)
                  {
                    throw (Exception)rUser;
                  }

                  break;
                }
              case 2:
                {
                  person.Estatus = 3;
                  WriteLine("Denegado!");
                  db.SaveChanges();
                  break;
                }
            }
          }
        }
      }
    }

    public static void bajaUsuarios(AutoModel.Gerente gerente)
    {
      Write("Ingrese el id del usuario a dar de baja : ");
      string? id = ReadLine();
      var rGerente = gerente.BajaUsuario(int.Parse(id));

      if (rGerente is Exception)
      {
        throw new Exception("Error al dar de baja al usuario");
      }

      WriteLine("Usuario dado de baja con exito");
    }

    public static void checarBajaUsuario()
    {
      using (var db = new AutoModel.bancoContext())
      {
        var query = db.Usuarios.Where(u => u.FechaBaja != null).ToList();

        if (query.Count is 0)
        {
          // throw new Exception("No hay usuarios dados de baja");
        }
        foreach (var item in query)
        {
          if (DateOnly.FromDateTime(DateTime.Now) > item.FechaBaja.Value.AddMonths(6))
          {
            var prestamos = db.Prestamos.Where(p => p.UsuarioId == item.Id).ToList();
            db.Prestamos.RemoveRange(prestamos);
            db.SaveChanges();
          }
        }
      }
    }
  }
}