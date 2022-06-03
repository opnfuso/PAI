using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace P11
{
  public partial class Persona
  {
    public Persona()
    {
      Solicituds = new HashSet<Solicitud>();
    }

    public int Id { get; set; }
    public string PrimerNombre { get; set; } = null!;
    public string? SegundoNombre { get; set; }
    public string PrimerApellido { get; set; } = null!;
    public string SegundoApellido { get; set; } = null!;
    public DateTime FechaNacimiento { get; set; }
    public string Curp { get; set; } = null!;

    // public virtual Usuario Usuario { get; set; } = null!;
    public virtual ICollection<Solicitud> Solicituds { get; set; }

    public object GetAll()
    {
      using (var db = new bancoContext())
      {
        return db.Personas.ToList();
      }
    }

    public object Get(int id)
    {
      using (var db = new bancoContext())
      {
        var persona = db.Personas.Find(id);
        if (persona == null)
        {
          return null;
        }

        return persona;
      }
    }

    // public bool CURPValidator(string curp, string Pname, string Pap, string Sap, DateTime bornday)
    // {

    // }
    public object Create(string Pn, string Sn, string Pa, string Sa, DateTime bornday, string curp)
    {
      using (var db = new bancoContext())
      {
        var persona = new Persona();

        persona.PrimerNombre = Pn;
        bool flag = Pn.Any(char.IsDigit);
        if (flag == true)
        {
          return new Exception("Los Nombres no pueden llevar numeros..");
        }
        flag = persona.PrimerNombre.Any(char.IsSymbol);
        if (flag == true)
        {
          return new Exception("Los Nombres no pueden llevar simbolos..");
        }

        persona.SegundoNombre = Sn;
        flag = persona.SegundoNombre.Any(char.IsDigit);
        if (flag == true)
        {
          return new Exception("Los Nombres no pueden llevar numeros..");
        }
        flag = persona.SegundoNombre.Any(char.IsSymbol);
        if (flag == true)
        {
          return new Exception("Los Nombres no pueden llevar simbolos..");
        }

        persona.PrimerApellido = Pa;
        flag = persona.PrimerApellido.Any(char.IsDigit);
        if (flag == true)
        {
          return new Exception("Los Apellidos no pueden llevar numeros..");
        }
        flag = persona.PrimerApellido.Any(char.IsSymbol);
        if (flag == true)
        {
          return new Exception("Los Nombres no pueden llevar simbolos..");
        }

        persona.SegundoApellido = Sa;
        flag = persona.SegundoApellido.Any(char.IsDigit);
        if (flag == true)
        {
          return new Exception("Los Apellidos no pueden llevar numeros..");
        }
        flag = persona.SegundoApellido.Any(char.IsSymbol);
        if (flag == true)
        {
          return new Exception("Los Nombres no pueden llevar simbolos..");
        }

        persona.FechaNacimiento = bornday;
        if (persona.FechaNacimiento.Year < 1962)
        {
          return new Exception("La fecha de nacimiento no puede ser menor a 1962");
        }

        persona.Curp = curp;
        // bool flag2 = CURPValidator(persona.Curp, persona.PrimerNombre, persona.PrimerApellido, persona.SegundoApellido, persona.FechaNacimiento);
        // if (flag2 == false)
        // {
        //   return new Exception("El CURP No coincide con los datos anteriormente agregados.");
        // }
        db.Personas.Add(persona);
        db.SaveChanges();

        var soli = new Solicitud()
        {
          PersonaId = persona.Id,
          Estatus = 1
        };

        db.Solicituds.Add(soli);
        db.SaveChanges();

        return persona;
      }
    }
  }

  public class PersonaCreate
  {
    [Required]
    [RegularExpression(@"^[a-zA-ZñÑ]+", ErrorMessage = "Solo se permiten letras")]
    public string PrimerNombre { get; set; } = null!;
    [RegularExpression(@"^[a-zA-ZñÑ]+", ErrorMessage = "Solo se permiten letras")]
    public string? SegundoNombre { get; set; }
    [Required]
    [RegularExpression(@"^[a-zA-ZñÑ]+", ErrorMessage = "Solo se permiten letras")]
    public string PrimerApellido { get; set; } = null!;
    [Required]
    [RegularExpression(@"^[a-zA-ZñÑ]+", ErrorMessage = "Solo se permiten letras")]
    public string SegundoApellido { get; set; } = null!;
    [Required]
    [DataType(DataType.Date)]
    public DateTime FechaNacimiento { get; set; }
    [Required]
    [StringLength(10, MinimumLength = 10, ErrorMessage = "El CURP debe tener al menos 10 caracteres")]
    public string Curp { get; set; } = null!;

    public Persona Create(PersonaCreate personaCreate)
    {
      string Pn = personaCreate.PrimerNombre;
      string Sn = personaCreate.SegundoNombre;
      string Pa = personaCreate.PrimerApellido;
      string Sa = personaCreate.SegundoApellido;
      DateTime nacimiento = personaCreate.FechaNacimiento;
      string curp = personaCreate.Curp;

      using (var db = new bancoContext())
      {
        var persona = new Persona();

        persona.PrimerNombre = Pn;
        persona.SegundoNombre = Sn;
        persona.PrimerApellido = Pa;
        persona.SegundoApellido = Sa;
        persona.FechaNacimiento = nacimiento;
        persona.Curp = curp;

        db.Personas.Add(persona);
        db.SaveChanges();

        return persona;
      }
    }
  }
}
