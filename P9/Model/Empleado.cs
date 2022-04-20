using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace P9
{
  public class Empleado
  {
    public Empleado()
    {
      Prestamos = new HashSet<Prestamo>();
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
    public bool activo { get; set; } = true;
    public virtual ICollection<Prestamo> Prestamos { get; set; }
  }
}