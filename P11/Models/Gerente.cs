using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace P11
{
  public partial class Gerente
  {
    public Gerente()
    {
      Prestamos = new HashSet<Prestamo>();
      Solicituds = new HashSet<Solicitud>();
      Pagos = new HashSet<Pago>();
      // Cuenta = new HashSet<Cuenta>();
    }

    public int Id { get; set; }
    public string PrimerNombre { get; set; } = null!;
    public string? SegundoNombre { get; set; }
    public string PrimerApellido { get; set; } = null!;
    public string SegundoApellido { get; set; } = null!;
    public DateTime FechaNacimiento { get; set; }
    public DateTime FechaIncorporacion { get; set; }
    public DateTime UltimasVacaciones { get; set; }
    // public string Password { get; set; } = null!;
    public int? DiasVaca { get; set; }
    public int? DiasSeguidos { get; set; }
    public decimal Saldo { get; set; }

    // public virtual ICollection<Cuenta> Cuenta { get; set; }
    public virtual ICollection<Prestamo> Prestamos { get; set; }
    public virtual ICollection<Pago> Pagos { get; set; }
    public virtual ICollection<Solicitud> Solicituds { get; set; }

    public object GetAll()
    {
      using (var db = new bancoContext())
      {
        return db.Gerentes.ToList();
      }
    }

    public object Get(int id)
    {
      using (var db = new bancoContext())
      {
        var gerente = db.Gerentes.Find(id);
        if (gerente == null)
        {
          return null;
        }

        return gerente;
      }
    }
    // public object login(int user, string pass)
    // {
    //   using (var db = new bancoContext())
    //   {
    //     var gerente = db.Gerentes.Where(u => u.Id == user && u.Password == pass).FirstOrDefault();

    //     if (gerente == null)
    //     {
    //       return new Exception("Usuario o contraseña inválidos");
    //     }

    //     return gerente;
    //   }
    // }

    public object Create(string Pa, string Sa, string Pn, string Sn, DateTime nacimiento)
    {
      using (var db = new bancoContext())
      {
        if (Pn == null || Pa == null || Sa == null)
        {
          return new Exception("Algun dato es nulo");
        }

        bool flag = Pn.Any(char.IsDigit);
        if (flag == true)
        {
          return new Exception("Los Nombres no pueden llevar numeros..");
        }
        flag = Pn.Any(char.IsSymbol);
        if (flag == true)
        {
          return new Exception("Los Nombres no pueden llevar simbolos..");
        }

        if (Sn is not null)
        {
          flag = Sn.Any(char.IsDigit);
          if (flag == true)
          {
            return new Exception("Los Nombres no pueden llevar numeros..");
          }
          flag = Sn.Any(char.IsSymbol);
          if (flag == true)
          {
            return new Exception("Los Nombres no pueden llevar simbolos..");
          }
        }

        flag = Pa.Any(char.IsDigit);
        if (flag == true)
        {
          return new Exception("Los Apellidos no pueden llevar numeros..");
        }
        flag = Pa.Any(char.IsSymbol);
        if (flag == true)
        {
          return new Exception("Los Apellidos no pueden llevar simbolos..");
        }

        flag = Sa.Any(char.IsDigit);
        if (flag == true)
        {
          return new Exception("Los Apellidos no pueden llevar numeros..");
        }
        flag = Sa.Any(char.IsSymbol);
        if (flag == true)
        {
          return new Exception("Los Apellidos no pueden llevar simbolos..");
        }

        var gerente = new Gerente();

        gerente.PrimerNombre = Pn;
        gerente.SegundoNombre = Sn;
        gerente.PrimerApellido = Pa;
        gerente.SegundoApellido = Sa;
        // gerente.Password = pass;
        gerente.FechaIncorporacion = DateTime.Now;
        gerente.FechaNacimiento = nacimiento;

        db.Gerentes.Add(gerente);
        db.SaveChanges();

        // var cuenta = new Cuenta();
        // cuenta.NCuentaGerente = gerente.Id;
        // cuenta.Tipo = 1;
        // db.Cuentas.Add(cuenta);
        // db.SaveChanges();

        return gerente;
      }
    }
  }

  public class GerenteCreate
  {
    [Required]
    [RegularExpression(@"^[a-zA-ZñÑ]+", ErrorMessage = "Solo se permiten letras")]
    public string? PrimerNombre { get; set; }
    [RegularExpression(@"^[a-zA-ZñÑ]+", ErrorMessage = "Solo se permiten letras")]
    public string? SegundoNombre { get; set; }
    [Required]
    [RegularExpression(@"^[a-zA-ZñÑ]+", ErrorMessage = "Solo se permiten letras")]
    public string? PrimerApellido { get; set; }
    [Required]
    [RegularExpression(@"^[a-zA-ZñÑ]+", ErrorMessage = "Solo se permiten letras")]
    public string? SegundoApellido { get; set; }
    [Required]
    [DataType(DataType.Date)]
    public DateTime FechaNacimiento { get; set; }

    public Gerente Create(GerenteCreate empleadoCreate)
    {
      var Pn = empleadoCreate.PrimerNombre;
      var Sn = empleadoCreate.SegundoNombre;
      var Pa = empleadoCreate.PrimerApellido;
      var Sa = empleadoCreate.SegundoApellido;
      var nacimiento = empleadoCreate.FechaNacimiento;
      using (var db = new bancoContext())
      {
        var gerente = new Gerente();

        gerente.PrimerNombre = Pn;
        gerente.SegundoNombre = Sn;
        gerente.PrimerApellido = Pa;
        gerente.SegundoApellido = Sa;
        // gerente.Activo = true;
        gerente.FechaNacimiento = nacimiento;
        gerente.FechaIncorporacion = DateTime.Now;
        // empleado.Password = pass;

        db.Gerentes.Add(gerente);
        db.SaveChanges();

        // var cuenta = new Cuenta();
        // cuenta.NCuentaEmpleado = empleado.Id;
        // cuenta.Tipo = 2;
        // db.Cuentas.Add(cuenta);
        // db.SaveChanges();

        return gerente;
      }
    }
  }

  public class GerenteUpdate
  {
    [Required]
    [RegularExpression(@"^[a-zA-ZñÑ]+", ErrorMessage = "Solo se permiten letras")]
    public string? PrimerNombre { get; set; }
    [RegularExpression(@"^[a-zA-ZñÑ]+", ErrorMessage = "Solo se permiten letras")]
    public string? SegundoNombre { get; set; }
    [Required]
    [RegularExpression(@"^[a-zA-ZñÑ]+", ErrorMessage = "Solo se permiten letras")]
    public string? PrimerApellido { get; set; }
    [Required]
    [RegularExpression(@"^[a-zA-ZñÑ]+", ErrorMessage = "Solo se permiten letras")]
    public string? SegundoApellido { get; set; }
    [Required]
    [DataType(DataType.Date)]
    public DateTime FechaNacimiento { get; set; }

    public Gerente Update(int id, GerenteUpdate gerenteCreate)
    {
      var Pn = gerenteCreate.PrimerNombre;
      var Sn = gerenteCreate.SegundoNombre;
      var Pa = gerenteCreate.PrimerApellido;
      var Sa = gerenteCreate.SegundoApellido;
      var nacimiento = gerenteCreate.FechaNacimiento;
      using (var db = new bancoContext())
      {
        var gerente = db.Gerentes.Find(id);

        gerente.PrimerNombre = Pn;
        gerente.SegundoNombre = Sn;
        gerente.PrimerApellido = Pa;
        gerente.SegundoApellido = Sa;
        gerente.FechaNacimiento = nacimiento;

        db.SaveChanges();

        return gerente;
      }
    }
  }
}
