using System;
using static System.Console;
namespace P9
{
  class Program
  {
    public static void Main(string[] args)
    {
      // WriteLine($"Using {ProgramConstants.DataBaseProvider} database provider.");
      QueryingPeople();
    }

    static void QueryingPeople()
    {
      using (AutoModel.bancoContext db = new())
      {
        var data = db.Personas.Join(db.Usuarios,
          persona => persona.Id,
          usuario => usuario.PersonaId,
          (persona, usuario) => new
          {
            Persona = persona,
            Usuario = usuario
          }).ToList();

        foreach (var item in data)
        {
          WriteLine($"{item.Persona.PrimerNombre} {item.Persona.PrimerApellido}");
          WriteLine($"{item.Usuario.NombreUsuario}");
        }
      }
    }
  }
}