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

    public object Delete(int id)
    {
      using (var db = new bancoContext())
      {
        var persona = db.Personas.Find(id);
        if (persona == null)
        {
          return null;
        }

        // Delete persona
        db.Personas.Remove(persona);
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
    [Range(typeof(DateTime), "1962/01/01", "9999/12/31", ErrorMessage = "La fecha de nacimiento no puede ser menor a 1962")]
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

  public class PersonaUpdate
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
    [Range(typeof(DateTime), "1962/01/01", "9999/12/31", ErrorMessage = "La fecha de nacimiento no puede ser menor a 1962")]
    public DateTime FechaNacimiento { get; set; }
    [Required]
    [StringLength(10, MinimumLength = 10, ErrorMessage = "El CURP debe tener al menos 10 caracteres")]
    public string Curp { get; set; } = null!;

    public Persona Update(int id, PersonaUpdate personaUpdate)
    {
      string Pn = personaUpdate.PrimerNombre;
      string Sn = personaUpdate.SegundoNombre;
      string Pa = personaUpdate.PrimerApellido;
      string Sa = personaUpdate.SegundoApellido;
      DateTime nacimiento = personaUpdate.FechaNacimiento;
      string curp = personaUpdate.Curp;

      using (var db = new bancoContext())
      {
        var persona = db.Personas.Find(id);

        persona.PrimerNombre = Pn;
        persona.SegundoNombre = Sn;
        persona.PrimerApellido = Pa;
        persona.SegundoApellido = Sa;
        persona.FechaNacimiento = nacimiento;
        persona.Curp = curp;

        db.SaveChanges();

        return persona;
      }
    }
  }
}
