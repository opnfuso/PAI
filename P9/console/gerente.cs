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
        WriteLine("8.Reanudar prestamos");
        WriteLine("9.Pedir un prestamo");
        WriteLine("10.Aprobar solicitudes de usuarios");
        WriteLine("11.Añadir gerente");
        WriteLine("12.Añadir saldo");
        WriteLine("13.Salir");
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
            pedirVacaciones(gerente);
            break;

          case "3":
            aceptarPrestamosGerente(gerente);
            break;

          case "4":
            generarReportes();
            break;

          case "5":
            bajaEmpleados(gerente);
            break;

          case "6":
            bajaUsuarios(gerente);
            break;

          case "7":
            pausarPrestamos(gerente);
            break;

          case "8":
            reanudarPrestamos(gerente);
            break;

          case "9":
            pedirPrestamoGerente(gerente);
            break;

          case "10":
            aceptarUsuarios(gerente);
            break;

          case "11":
            addGerente(gerente);
            break;

          case "12":
            addSaldoGerente(gerente);
            break;

          case "13":
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
    public static void pausarPrestamos(AutoModel.Gerente gerente)
    {
      Write("Ingrese el id del prestamo a pausar : ");
      string? id = ReadLine();
      var rGerente = gerente.PausarPrestamo(int.Parse(id));

      if (rGerente is Exception)
      {
        throw new Exception("Error al pausar el prestamo");
      }

      WriteLine("Prestamo pausado con exito");
    }

    public static void reanudarPrestamos(AutoModel.Gerente gerente)
    {
      using (var db = new AutoModel.bancoContext())
      {
        var prestamos = db.Prestamos.Where(p => p.Activo == false && p.FechaPausa != null).ToList();

        if (prestamos.Count is 0)
        {
          throw new Exception("No hay prestamos pausados");
        }
        else
        {
          foreach (var item in prestamos)
          {
            WriteLine($"Id del prestamo: {item.Id} fecha de pausa: {item.FechaPausa}");
          }
          Write("ID Prestamo : ");
          int id = int.Parse(ReadLine());
        }
      }
    }

    public static void checarPrestamos()
    {
      using (var db = new AutoModel.bancoContext())
      {
        var gerente = new AutoModel.Gerente();
        var query = db.Prestamos.Where(p => p.Activo == false && p.FechaPausa != null).ToList();

        if (query.Count is 0)
        {
          // throw new Exception("No hay usuarios dados de baja");
        }
        else
        {
          foreach (var item in query)
          {
            if (DateOnly.FromDateTime(DateTime.Now) >= item.FechaPausa.Value.AddMonths(2))
            {
              gerente.ReanudarPrestamo(item.Id);
            }
          }
        }
      }
    }

    static void generarReportes()
    {
      int opcion;
      bool banparse = false;
      WriteLine("1.Reportes por dia \n2. Reporte por mes \n3. Reporte por usuario \n4. Reporte por tipo \n5. Reporte por ultima semana ");

      do
      {
        banparse = int.TryParse(ReadLine(), out opcion);
      } while (!banparse);

      switch (opcion)
      {
        case 1: //Reportes por Dia
          using (AutoModel.bancoContext db = new())
          {
            var queryinfo = db.SolicitudPrestamos.Where(e => e.Estatus == 2).Select(a => new
            {
              Sprestamo = a,
              pertenece = a.Usuario.NombreUsuario,
              idprestamo = a.PrestamoId,
              iduser = a.UsuarioId,
              fsolicitud = a.Prestamo.FechaSolicitud,
              faprobacion = a.Prestamo.FechaAprobacion,

            }
            ).ToList().OrderBy(a => a.faprobacion);
            //PARA RECORRER POR DIAS
            var queryDIAS = db.Prestamos.Select(a => new
            {
              Prestamo = a,
              diaxaprobasion = a.FechaAprobacion,
            }
            ).ToList().OrderBy(a => a.diaxaprobasion).DistinctBy(o => o.diaxaprobasion);


            foreach (var item in queryDIAS)
            {
              WriteLine(item.diaxaprobasion);
            }

            foreach (var item in queryDIAS)
            {
              WriteLine($"Prestamos con fecha {item.diaxaprobasion}");
              foreach (var itemXD in queryinfo)
              {

                if (itemXD.faprobacion == item.diaxaprobasion)
                {

                  WriteLine($" [No. Folio {itemXD.idprestamo}] [Fecha de aprobacion {itemXD.faprobacion}] [Fecha de solicitud {itemXD.fsolicitud}] [Prestamo de {itemXD.pertenece}] [Con id {itemXD.iduser}]");
                  var ultimopago = db.Pagos.Where(a => a.PrestamoId == itemXD.idprestamo).OrderByDescending(o => o.Id).FirstOrDefault();
                  if (ultimopago is null)
                  { }
                  else
                  {
                    WriteLine($" [Ultimo pago de: {ultimopago.Cantidad}] [El {ultimopago.Fecha}] ");
                  }

                }

              }

            }
          }

          break;

        case 2:
          using (AutoModel.bancoContext db = new())
          {
            var queryinfo = db.SolicitudPrestamos.Where(e => e.Estatus == 2).Select(a => new
            {
              Sprestamo = a,
              pertenece = a.Usuario.NombreUsuario,
              idprestamo = a.PrestamoId,
              iduser = a.UsuarioId,
              fsolicitud = a.Prestamo.FechaSolicitud,
              faprobacion = a.Prestamo.FechaAprobacion

            }
                    ).ToList().OrderBy(a => a.faprobacion);

            for (var i = 1; i <= 12; i++)
            {
              DateTime strDate = new DateTime(2000, i, 1);
              WriteLine($"Prestamos en el mes {strDate.ToString("MMMM")}");

              foreach (var item in queryinfo)
              {
                if (item.faprobacion.HasValue == true)
                {

                  if (item.faprobacion.Value.Month == i)
                  {

                    WriteLine($" [No. Folio {item.idprestamo}] [Fecha de aprobacion {item.faprobacion}] [Fecha de solicitud {item.fsolicitud}] [Prestamo de {item.pertenece}] [Con id {item.iduser}]");
                    var ultimopago = db.Pagos.Where(a => a.PrestamoId == item.idprestamo).OrderByDescending(o => o.Id).FirstOrDefault();
                    if (ultimopago is null)
                    { }
                    else
                    {
                      WriteLine($" [Ultimo pago de: {ultimopago.Cantidad}] [El {ultimopago.Fecha}] ");
                    }
                  }
                }
              }
            }


          }



          break;
        case 3://POR usuario
               //OBTENER NUMERO DE CUENTA
          WriteLine("[Escribe el numero de cuenta del usuario con el que se quiere trabajar]");
          var rid = ReadLine();

          if (rid is null)
          {
            throw new Exception("No se ha ingresado un numero de cuenta");
          }

          long id = long.Parse(rid);

          using (AutoModel.bancoContext db = new())
          {
            var UserID = db.Cuentas.Where(a => a.Id == id).FirstOrDefault();
            id = (long)UserID.NCuentaUsuario;

            if (UserID is null)
            {
              throw new Exception("[No se encontro el usuario]");
            }
            WriteLine($"[La id del usuario despite el numero de cuenta{id}]");
            //ENLISTAR TODOS LOS PRESTAMOS DEL USUARIO
            var queryinfo = db.SolicitudPrestamos.Where(e => e.Estatus == 2 && e.UsuarioId == id).Select(a => new
            {
              Sprestamo = a,
              pertenece = a.Usuario.NombreUsuario,
              idprestamo = a.PrestamoId,
              iduser = a.UsuarioId,
              fsolicitud = a.Prestamo.FechaSolicitud,
              faprobacion = a.Prestamo.FechaAprobacion

            }
            ).ToList().OrderBy(a => a.faprobacion);

            foreach (var item in queryinfo)
            {
              var ultimopago = db.Pagos.Where(a => a.PrestamoId == item.idprestamo).OrderByDescending(o => o.Id).FirstOrDefault();
              WriteLine($" [No. Folio {item.idprestamo}] [Fecha de aprobacion {item.faprobacion}] [Fecha de solicitud {item.fsolicitud}] [Prestamo de {item.pertenece}] [Con id {item.iduser}]");
              if (ultimopago is null)
              { }
              else
              {
                WriteLine($" [Ultimo pago de: {ultimopago.Cantidad}] [El {ultimopago.Fecha}] ");
              }
            }


          }

          break;
        case 4: //POR TIPO
          using (AutoModel.bancoContext db = new())
          {
            var queryinfo = db.SolicitudPrestamos.Where(e => e.Estatus == 2).Select(a => new
            {
              Sprestamo = a,
              pertenece = a.Usuario.NombreUsuario,
              idprestamo = a.PrestamoId,
              iduser = a.UsuarioId,
              fsolicitud = a.Prestamo.FechaSolicitud,
              faprobacion = a.Prestamo.FechaAprobacion,
              meses = a.Prestamo.Meses

            }
                    ).ToList().OrderBy(a => a.meses);
            //IMPRIMIR 6 MESES
            WriteLine("[Prestamos de 6 meses]");
            foreach (var item in queryinfo)
            {
              if (item.meses == 6)
                WriteLine($" [No. Folio {item.idprestamo}] [Fecha de aprobacion {item.faprobacion}] [Fecha de solicitud {item.fsolicitud}] [Prestamo de {item.pertenece}] [Con id {item.iduser}]");
            }

            //IMPRIMIR 12 MESES
            WriteLine("[Prestamos de 12 meses]");
            foreach (var item in queryinfo)
            {
              if (item.meses == 12)
                WriteLine($" [No. Folio {item.idprestamo}] [Fecha de aprobacion {item.faprobacion}] [Fecha de solicitud {item.fsolicitud}] [Prestamo de {item.pertenece}] [Con id {item.iduser}]");
            }

            WriteLine("[Prestamos de 24 meses]");
            foreach (var item in queryinfo)
            {
              if (item.meses == 24)
                WriteLine($" [No. Folio {item.idprestamo}] [Fecha de aprobacion {item.faprobacion}] [Fecha de solicitud {item.fsolicitud}] [Prestamo de {item.pertenece}] [Con id {item.iduser}]");
            }

            WriteLine("[Prestamos de 36 meses]");
            foreach (var item in queryinfo)
            {
              if (item.meses == 36)
                WriteLine($" [No. Folio {item.idprestamo}] [Fecha de aprobacion {item.faprobacion}] [Fecha de solicitud {item.fsolicitud}] [Prestamo de {item.pertenece}] [Con id {item.iduser}]");
            }


          }


          break;
        case 5:
          using (AutoModel.bancoContext db = new())
          {
            var queryinfo = db.SolicitudPrestamos.Where(e => e.Estatus == 2).Select(a => new
            {
              Sprestamo = a,
              pertenece = a.Usuario.NombreUsuario,
              idprestamo = a.PrestamoId,
              iduser = a.UsuarioId,
              fsolicitud = a.Prestamo.FechaSolicitud,
              faprobacion = a.Prestamo.FechaAprobacion,
              meses = a.Prestamo.Meses

            }
                    ).ToList().OrderBy(a => a.meses);
            var dateAndTime = DateTime.Now;
            DateOnly aora = DateOnly.FromDateTime(dateAndTime);
            WriteLine("[Prestamos realizados esta ultima semana]");
            for (var i = 1; i <= 7; i++)
            {
              foreach (var item in queryinfo)
              {
                if (item.faprobacion == aora)
                  WriteLine($" [No. Folio {item.idprestamo}] [Fecha de aprobacion {item.faprobacion}] [Fecha de solicitud {item.fsolicitud}] [Prestamo de {item.pertenece}] [Con id {item.iduser}]");
              }
              aora = aora.AddDays(-1);
              //WriteLine(aora);
            }

          }
          break;
        default:
          WriteLine("[Se ha elegido una opcion no existente]");
          break;
      }

    }

    public static void AddDayVacations()
    {

      try
      {
        using (var db = new AutoModel.bancoContext())
        {
          var gerente = db.Gerentes.ToList();

          var time = DateTime.Now;

          foreach (var item in gerente)
          {
            int diferenciaMeses = (DateOnly.FromDateTime(time).Month - item.FechaIncorporacion.Month);
            int difereciaAnos = (DateOnly.FromDateTime(time).Year - item.FechaIncorporacion.Year);
            if (difereciaAnos == 0)
            {
              if (diferenciaMeses > 0)
              {
                if (diferenciaMeses >= 10)
                {
                  item.DiasVaca = 10;
                }
                else
                {
                  item.DiasVaca = diferenciaMeses;
                  if (item.DiasVaca < 0)
                  {
                    item.DiasVaca = 0;
                  }
                }
              }
              else
              {
                item.DiasVaca = 0;
              }
              if (item.DiasVaca is not null)
              {
                item.DiasVaca = item.DiasVaca - item.DiasVaca;
                if (item.DiasVaca < 0)
                {
                  item.DiasVaca = 0;
                }
              }
            }
            else
            {

              if (item.UltimasVacaciones.Year < DateOnly.FromDateTime(time).Year)
              {
                item.DiasVaca = 0;
              }

              item.DiasVaca = time.Month;
              if (item.DiasVaca > 10)
              {
                item.DiasVaca = 10;
              }
              if (item.DiasVaca is not null)
              {
                item.DiasVaca = item.DiasVaca - item.DiasVaca;
                if (item.DiasVaca < 0)
                {
                  item.DiasVaca = 0;
                }
              }

            }
          }
          db.SaveChanges();
        }
      }
      catch (System.Exception ex)
      {
        throw (ex);
      }

    }

    public static void pedirVacaciones(AutoModel.Gerente gerente)
    {
      bool flag = true;
      do
      {
        try
        {
          using (var db = new AutoModel.bancoContext())
          {
            var time = DateTime.Now;
            if (gerente.DiasVaca < 10)
            {
              Write("Dia de Vacacion:");
              DateOnly vacacion_soli;
              vacacion_soli = DateOnly.Parse(ReadLine());
              if (vacacion_soli.Year == DateOnly.FromDateTime(time).Year)
              {
                flag = true;
                if (gerente.DiasVaca > 0)
                {
                  if (vacacion_soli == gerente.UltimasVacaciones.AddDays(1))
                  {
                    if (gerente.DiasSeguidos < 4)
                    {
                      gerente.DiasSeguidos++;
                      gerente.DiasVaca--;
                      gerente.UltimasVacaciones = vacacion_soli;
                      gerente.DiasVaca++;
                      WriteLine("Vacaciones Solicitadas!");
                      db.SaveChanges();
                    }
                    else
                    {
                      throw new Exception("Maximo De Dias Seguidos de vacaciones alcanzado..");
                    }
                  }
                  else
                  {
                    gerente.DiasSeguidos = 1;
                    gerente.DiasVaca--;
                    gerente.UltimasVacaciones = vacacion_soli;
                    gerente.DiasVaca++;
                    WriteLine("Vacaciones Solicitadas!");
                    db.SaveChanges();
                  }

                }
                else
                {
                  throw new Exception("No dispones de dias de vacaciones aun...");
                }
              }
              else
              {
                flag = false;
                throw new Exception("Las Vacaciones no pueden ser de proximos años u anteriores al actual.");
              }
            }
            else
            {
              flag = false;
              throw new Exception("Maximo de Vacaciones Alcanzadas Espere Hasta el siguiente Año!");
            }

          }
        }
        catch (System.Exception ex)
        {
          flag = !flag;
          WriteLine(ex);
        }

      } while (flag == false);

    }
    public static void addSaldoGerente(AutoModel.Gerente gerente)
    {
      WriteLine("\n\tAñadir saldo");
      Write("Monto:");
      var monto = decimal.Parse(ReadLine());
      var rSaldo = gerente.AddSaldo(gerente.Id, monto);
      WriteLine("Saldo actualizado");
    }
  }
}