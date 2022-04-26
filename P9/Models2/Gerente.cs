using System;
using System.Collections.Generic;

namespace P9.Models2
{
    public partial class Gerente
    {
        public Gerente()
        {
            Cuenta = new HashSet<Cuenta>();
            Prestamos = new HashSet<Prestamo>();
            Solicituds = new HashSet<Solicitud>();
        }

        public long Id { get; set; }
        public string PrimerNombre { get; set; } = null!;
        public string? SegundoNombre { get; set; }
        public string PrimerApellido { get; set; } = null!;
        public string SegundoApellido { get; set; } = null!;
        public byte[] FechaNacimiento { get; set; } = null!;
        public byte[] FechaIncorporacion { get; set; } = null!;
        public byte[]? UltimasVacaciones { get; set; }
        public string Password { get; set; } = null!;
        public long? DiasVaca { get; set; }
        public long? DiasSeguidos { get; set; }

        public virtual ICollection<Cuenta> Cuenta { get; set; }
        public virtual ICollection<Prestamo> Prestamos { get; set; }
        public virtual ICollection<Solicitud> Solicituds { get; set; }
    }
}
