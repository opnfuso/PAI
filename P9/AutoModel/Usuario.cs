using System;
using System.Collections.Generic;

namespace P9.AutoModel
{
  public partial class Usuario
  {
    public Usuario()
    {
      Pagos = new HashSet<Pago>();
      Prestamos = new HashSet<Prestamo>();
      SolicitudPrestamos = new HashSet<SolicitudPrestamo>();
      Solicituds = new HashSet<Solicitud>();
    }

    public int Id { get; set; }
    public int PersonaId { get; set; }
    public string NombreUsuario { get; set; } = null!;
    public string Password { get; set; } = null!;
    public decimal Saldo { get; set; }
    public bool Activo { get; set; }
    public int Intentos { get; set; }

    public virtual Persona Persona { get; set; } = null!;
    public virtual ICollection<Pago> Pagos { get; set; }
    public virtual ICollection<Prestamo> Prestamos { get; set; }
    public virtual ICollection<SolicitudPrestamo> SolicitudPrestamos { get; set; }
    public virtual ICollection<Solicitud> Solicituds { get; set; }
  }
}
