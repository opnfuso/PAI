using System;
using System.Collections.Generic;

namespace P9.AutoModel
{
  public partial class Solicitud
  {
    public int Id { get; set; }
    public int PersonaId { get; set; }
    public int UsuarioId { get; set; }
    public int GerenteId { get; set; }
    public int Estatus { get; set; }

    public virtual Gerente Gerente { get; set; } = null!;
    public virtual Persona Persona { get; set; } = null!;
    public virtual Usuario Usuario { get; set; } = null!;
  }
}
