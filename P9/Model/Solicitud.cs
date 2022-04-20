using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace P9
{
  public class Solicitud
  {
    [Required]
    public int id { get; set; }
    [Required]
    public int persona_id { get; set; }
    [Required]
    public int gerente_id { get; set; }
    [Required]
    public int usuario_id { get; set; }
    [Required]
    public double saldo { get; set; }
    [Required]
    [MaxLength(1)]
    public int activo { get; set; }

    public virtual Gerente Gerente { get; set; } = null!;
    public virtual Persona Persona { get; set; } = null!;
    public virtual Persona Usuario { get; set; } = null!;
  }
}