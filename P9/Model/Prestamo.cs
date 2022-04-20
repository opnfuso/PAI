using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace P9
{
  public partial class Prestamo
  {
    [Required]
    public int id { get; set; }
    [Required]
    public int usuario_id { get; set; }
    public int? empleado_id { get; set; }
    public int? gerente_id { get; set; }
    [Required]
    [StringLength(2)]
    public int meses { get; set; }
    [Required]
    public double cantidad { get; set; }
    [Required]
    public double pago_mes { get; set; }
    [Required]
    public DateTime fecha_solicitud { get; set; }
    public DateTime? fecha_aprobacion { get; set; }
    public DateTime? fecha_liquidacion { get; set; }
    [Required]
    public bool activo { get; set; } = true;

    public virtual Empleado? Empleado { get; set; }
    public virtual Gerente? Gerente { get; set; }
    public virtual Usuario Usuario { get; set; } = null!;
  }
}

