using System;
using System.Collections.Generic;

namespace P9.Models2
{
    public partial class Usuario
    {
        public Usuario()
        {
            Cuenta = new HashSet<Cuenta>();
            Pagos = new HashSet<Pago>();
            Prestamos = new HashSet<Prestamo>();
            SolicitudPrestamos = new HashSet<SolicitudPrestamo>();
            Solicituds = new HashSet<Solicitud>();
        }

        public long Id { get; set; }
        public long PersonaId { get; set; }
        public string NombreUsuario { get; set; } = null!;
        public string Password { get; set; } = null!;
        public byte[] Saldo { get; set; } = null!;
        public byte[] Activo { get; set; } = null!;
        public long Intentos { get; set; }
        public byte[]? TiempoBloqueo { get; set; }
        public byte[]? FechaBaja { get; set; }

        public virtual Persona Persona { get; set; } = null!;
        public virtual ICollection<Cuenta> Cuenta { get; set; }
        public virtual ICollection<Pago> Pagos { get; set; }
        public virtual ICollection<Prestamo> Prestamos { get; set; }
        public virtual ICollection<SolicitudPrestamo> SolicitudPrestamos { get; set; }
        public virtual ICollection<Solicitud> Solicituds { get; set; }
    }
}
