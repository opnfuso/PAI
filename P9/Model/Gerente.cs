using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace P9
{
  public class Gerente
  {
    public Gerente()
    {
      Prestamos = new HashSet<Prestamo>();
      Solicituds = new HashSet<Solicitud>();
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
    [Required]
    public DateTime fecha_incorporacion { get; set; }
    [Required]
    public DateTime ultimas_vacaciones { get; set; }
    public virtual ICollection<Prestamo> Prestamos { get; set; }
    public virtual ICollection<Solicitud> Solicituds { get; set; }
  }
}