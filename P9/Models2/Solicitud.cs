using System;
using System.Collections.Generic;

namespace P9.Models2
{
    public partial class Solicitud
    {
        public long Id { get; set; }
        public long PersonaId { get; set; }
        public long? UsuarioId { get; set; }
        public long? GerenteId { get; set; }
        public long Estatus { get; set; }

        public virtual Gerente? Gerente { get; set; }
        public virtual Persona Persona { get; set; } = null!;
        public virtual Usuario? Usuario { get; set; }
    }
}
