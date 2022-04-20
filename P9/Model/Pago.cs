using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace P9
{
  public class Pago
  {
    [Required]
    public int id { get; set; }
    [Required]
    public int usuario_id { get; set; }
    [Required]
    public int persona_id { get; set; }
    [Required]
    public double cantidad { get; set; }
    [Required]
    public DateTime fecha { get; set; }
    public virtual Persona Persona { get; set; } = null!;
    public virtual Usuario Usuario { get; set; } = null!;
  }
}