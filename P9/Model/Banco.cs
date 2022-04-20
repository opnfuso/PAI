using Microsoft.EntityFrameworkCore;
using static System.Console;
using static System.IO.Path;

namespace P9
{
  public class Banco : DbContext
  {
    public virtual DbSet<Empleado> Empleados { get; set; } = null!;
    public virtual DbSet<Gerente> Gerentes { get; set; } = null!;
    public virtual DbSet<Pago> Pagos { get; set; } = null!;
    public virtual DbSet<Persona> Personas { get; set; } = null!;
    public virtual DbSet<Prestamo> Prestamos { get; set; } = null!;
    public virtual DbSet<Solicitud> Solicituds { get; set; } = null!;
    public virtual DbSet<Usuario> Usuarios { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      if (ProgramConstants.DataBaseProvider == "SQLite")
      {
        string path = Combine(Environment.CurrentDirectory, "banco.db");
        WriteLine($"Using {path} database file.");
        // connection string
        optionsBuilder.UseSqlite($"FileName= {path}");
        //string connection = "Data Source= .;" + "Initial Catalog= Northwind;" + "Integrated Security= true;" + "MultipleActiveResultsSets= true;";

      }
    }
  }
}