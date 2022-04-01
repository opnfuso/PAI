using Microsoft.EntityFrameworkCore;
using static System.Console;
using static System.IO.Path;

namespace WorkingWithEFCore
{
  public class Northwind : DbContext
  {
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      if (ProgramConstants.DataBaseProvider == "SQLite")
      {
        string path = Combine(Environment.CurrentDirectory, "Northwind.db");
        WriteLine($"Using {path} database file");
        // connection string
        optionsBuilder.UseSqlite($"FileName= {path}");
        //string connection = "Data Source= + "Initial Catalog= Northwind;" + "Integrated Security= true;"
        .
      }
    }
  }
}