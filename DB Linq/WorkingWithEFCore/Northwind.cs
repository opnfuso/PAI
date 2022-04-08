using Microsoft.EntityFrameworkCore;
using static System.Console;
using static System.IO.Path;

namespace WorkingWithEFCore
{
    public class Northwind : DbContext
    {
        //DbContext
        // Maping the actual tables with DB Set
        // If we want all the other tables we need to map them here with DBSet
        public DbSet<Category>? Categories { get; set; }
        public DbSet<Product>? Products { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (ProgramConstants.DataBaseProvider == "SQLite")
            {
                string path = Combine(Environment.CurrentDirectory, "Northwind.db");
                WriteLine($"Using {path} database file.");
                // connection string
                optionsBuilder.UseSqlite($"FileName= {path}");
                //string connection = "Data Source= .;" + "Initial Catalog= Northwind;" + "Integrated Security= true;" + "MultipleActiveResultsSets= true;";

            }
        }

        // This function is to preload requirements or preload validations
        protected override void OnModelCreating( ModelBuilder modelBuilder)
        {
            //This is basically the same thing as using Atrributes like in Category or Product Class
            modelBuilder.Entity<Category>()
            .Property (category => category.CategoryName)
            .IsRequired()
            .HasMaxLength(15); // NOT NULL
            if(ProgramConstants.DataBaseProvider == "SQLite")
            {
                modelBuilder.Entity<Product>()
                .Property(product => product.Cost).HasConversion<double>();
            }
            // This is to filter the discontinued ones.
            modelBuilder.Entity<Product>()
            .HasQueryFilter(p => !p.Discontinued);
        }
        // After this, please in terminal put:
        // dotnet tool install --global dotnet-ef --version 6.0.1
        // After that ... SCAFFOLDING, the automatic shit that make more shit.
        // Scaffolding tool allows to automatically generate classes and regenerate classes without losing extended classes
        // Scaffolding command in terminal (large one):
        // dotnet ef dbcontext scaffold "Filename=Northwind.db" Microsoft.EntityFrameworkCore.Sqlite --table Categories --table Products --output-dir AutoGenModels --namespace WorkingWithEFCore.AutoGen --data-annotations --context Northwind
        // The folder AutoGenModels is with the scaffolded Models, compare AutoGenModels.Category with our own Category, so Products and so on so on ...
        // aaaaaaaaaaaaaaaaand that's it basically, now we start querying in Program.cs
    }
}