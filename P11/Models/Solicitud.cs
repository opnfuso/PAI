using System;
using System.Collections.Generic;

namespace P11
{
  public partial class Solicitud
  {
    public int Id { get; set; }
    public int PersonaId { get; set; }
    public long? UsuarioId { get; set; }
    public int? GerenteId { get; set; }
    public int Estatus { get; set; }

    public virtual Gerente? Gerente { get; set; }
    public virtual Persona Persona { get; set; } = null!;
    public virtual Usuario? Usuario { get; set; }
  }
}
