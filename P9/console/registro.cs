using System;
using static System.Console;

namespace P9
{
  partial class Program
  {
    public static void register()
    {
      var persona = new AutoModel.Persona();
      WriteLine("\n\tBanco de Préstamos");
      WriteLine("Ingrese su primer nombre: ");
      string? primerNombre = ReadLine();
      WriteLine("Ingrese su segundo nombre: ");
      string? segundoNombre = ReadLine();
      WriteLine("Ingrese su primer apellido: ");
      string? primerApellido = ReadLine();
      WriteLine("Ingrese su segundo apellido: ");
      string? segundoApellido = ReadLine();
      WriteLine("Ingrese su fecha de nacimiento en este formato dd-mm-yyyy: ");
      string? fechaNacimiento = ReadLine();
      WriteLine("Ingrese su CURP: ");
      string? curp = ReadLine();

      if (primerNombre == null || primerApellido == null || segundoApellido == null || fechaNacimiento == null || curp == null)
      {
        throw new Exception("Falta de datos");
      }

      DateOnly FechaNacimiento = DateOnly.Parse(fechaNacimiento);

      var newPersona = persona.Create(primerNombre, segundoNombre, primerApellido, segundoApellido, FechaNacimiento, curp);

      if (newPersona is Exception)
      {
        throw new Exception("Error al crear la persona");
      }

      WriteLine("Persona creada con exito");
    }
  }
}