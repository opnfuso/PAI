using System;
using System.Collections.Generic;

namespace P9.Models2
{
    public partial class Persona
    {
        public Persona()
        {
            Solicituds = new HashSet<Solicitud>();
        }

        public long Id { get; set; }
        public string PrimerNombre { get; set; } = null!;
        public string? SegundoNombre { get; set; }
        public string PrimerApellido { get; set; } = null!;
        public string SegundoApellido { get; set; } = null!;
        public byte[] FechaNacimiento { get; set; } = null!;
        public string Curp { get; set; } = null!;

        public virtual Usuario Usuario { get; set; } = null!;
        public virtual ICollection<Solicitud> Solicituds { get; set; }
    }
}
