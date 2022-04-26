using System;
using System.Collections.Generic;

namespace P9.Models2
{
    public partial class Empleado
    {
        public Empleado()
        {
            Cuenta = new HashSet<Cuenta>();
            Prestamos = new HashSet<Prestamo>();
        }

        public long Id { get; set; }
        public string PrimerNombre { get; set; } = null!;
        public string? SegundoNombre { get; set; }
        public string PrimerApellido { get; set; } = null!;
        public string SegundoApellido { get; set; } = null!;
        public byte[] FechaNacimiento { get; set; } = null!;
        public byte[] Activo { get; set; } = null!;
        public string Password { get; set; } = null!;

        public virtual ICollection<Cuenta> Cuenta { get; set; }
        public virtual ICollection<Prestamo> Prestamos { get; set; }
    }
}
