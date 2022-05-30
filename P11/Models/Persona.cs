using System;
using System.Collections.Generic;

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

    public virtual Usuario Usuario { get; set; } = null!;
    public virtual ICollection<Solicitud> Solicituds { get; set; }

    public object GetAll()
    {
      using (var db = new bancoContext())
      {
        return db.Personas.ToList();
      }
    }

    public object Get(long id)
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

    public bool CURPValidator(string curp, string Pname, string Pap, string Sap, DateTime bornday)
    {
      string fecha = bornday.ToString("yyMMdd");
      bool flag = false;
      bool vocal = false;
      string voc = "1";
      if (curp[0] == Pap[0])
      {
        flag = true;
        for (int i = 1; i < Pap.Length; i++)
        {
          if (IsVocal(Pap[i]) && vocal == false)
          {
            vocal = true;
            voc = Pap[i].ToString().ToUpper();
          }
        }
        if (curp[1].ToString() == voc)
        {
          if (curp[2] == Sap[0])
          {
            if (curp[3] == Pname[0])
            {
              for (int i = 0; i < fecha.Length; i++)
              {
                if (!(curp[i + 4] == fecha[i]))
                {
                  flag = false;
                }
              }
            }
            else
            {
              flag = false;
            }
          }
          else
          {
            flag = false;
          }
        }
        else
        {
          flag = false;
        }
      }
      return flag;
    }
    public bool IsVocal(char vocal)
    {
      char[] vocales = { 'A', 'a', 'I', 'i', 'U', 'u', 'E', 'e', 'O', 'o' };
      return vocales.Contains(vocal);
    }
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
        bool flag2 = CURPValidator(persona.Curp, persona.PrimerNombre, persona.PrimerApellido, persona.SegundoApellido, persona.FechaNacimiento);
        if (flag2 == false)
        {
          return new Exception("El CURP No coincide con los datos anteriormente agregados.");
        }
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
}
