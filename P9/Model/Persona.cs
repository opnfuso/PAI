using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace P9
{

  public class Persona
  {
    public Persona()
    {
      Pagos = new HashSet<Pago>();
      SolicitudPersonas = new HashSet<Solicitud>();
      SolicitudUsuarios = new HashSet<Solicitud>();
    }

    [Required]
    public int id { get; set; }
    [Required]
    [StringLength(30)]
    public string primer_nombre { get; set; } = null!;
    [Required]
    [StringLength(30)]
    public string? segundo_nombre { get; set; }
    [Required]
    [StringLength(30)]
    public string primer_apellido { get; set; } = null!;
    [Required]
    [StringLength(30)]
    public string segundo_apellido { get; set; } = null!;
    [Required]
    public DateTime fecha_nacimiento { get; set; }
    public virtual Usuario Usuario { get; set; } = null!;
    public virtual ICollection<Pago> Pagos { get; set; }
    public virtual ICollection<Solicitud> SolicitudPersonas { get; set; }
    public virtual ICollection<Solicitud> SolicitudUsuarios { get; set; }
  }
}