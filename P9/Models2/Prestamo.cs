using System;
using System.Collections.Generic;

namespace P9.Models2
{
    public partial class Prestamo
    {
        public Prestamo()
        {
            Pagos = new HashSet<Pago>();
            SolicitudPrestamos = new HashSet<SolicitudPrestamo>();
        }

        public long Id { get; set; }
        public long UsuarioId { get; set; }
        public long? EmpleadoId { get; set; }
        public long? GerenteId { get; set; }
        public long Meses { get; set; }
        public byte[] Cantidad { get; set; } = null!;
        public byte[] Interes { get; set; } = null!;
        public byte[] PagoMes { get; set; } = null!;
        public byte[] FechaSolicitud { get; set; } = null!;
        public byte[]? FechaAprobacion { get; set; }
        public byte[]? FechaLiquidacion { get; set; }
        public byte[] Activo { get; set; } = null!;
        public byte[]? FechaPausa { get; set; }

        public virtual Empleado? Empleado { get; set; }
        public virtual Gerente? Gerente { get; set; }
        public virtual Usuario Usuario { get; set; } = null!;
        public virtual ICollection<Pago> Pagos { get; set; }
        public virtual ICollection<SolicitudPrestamo> SolicitudPrestamos { get; set; }
    }
}
