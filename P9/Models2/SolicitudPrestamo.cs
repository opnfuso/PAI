using System;
using System.Collections.Generic;

namespace P9.Models2
{
    public partial class SolicitudPrestamo
    {
        public long Id { get; set; }
        public long UsuarioId { get; set; }
        public long PrestamoId { get; set; }
        public long Estatus { get; set; }

        public virtual Prestamo Prestamo { get; set; } = null!;
        public virtual Usuario Usuario { get; set; } = null!;
    }
}
