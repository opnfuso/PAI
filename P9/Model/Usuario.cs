using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace P9
{
  public class Usuario
  {
    public Usuario()
    {
      Pagos = new HashSet<Pago>();
      Prestamos = new HashSet<Prestamo>();
    }

    [Required]
    public int id { get; set; }
    [Required]
    public int persona_id { get; set; }
    [Required]
    [StringLength(50)]
    public string nombre_usuario { get; set; } = null!;
    [Required]
    [Column(TypeName = "ntext")]
    public string password { get; set; } = null!;
    [Required]
    public double saldo { get; set; }
    [Required]
    public bool activo { get; set; } = true;
    [Required]
    [MaxLength(1)]
    public int intentos { get; set; }
    public virtual Persona Persona { get; set; } = null!;
    public virtual ICollection<Pago> Pagos { get; set; }
    public virtual ICollection<Prestamo> Prestamos { get; set; }
  }
}