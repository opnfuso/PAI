using System;
using static System.Console;
namespace P7
{
  public partial class Program
  {
    static void crear_usuario()
    {
      WriteLine();
      Write("\nIngresa el numero de cuenta : ");
      string? ncuenta = ReadLine();
      uint num_cuenta = uint.Parse(ncuenta);
      Write("Ingresa el nombre : ");
      string? nombre = ReadLine();
      Write("Ingresa el apellido : ");
      string? apellido = ReadLine();
      Write("Ingresa el fecha de nacimiento : ");
      string? fecha = ReadLine();
      Write("Ingresa el nip : ");
      string? nip = ReadLine();
      WriteLine();
      DateOnly fecha_nacimiento = DateOnly.Parse(fecha);
      Usuario user = new Usuario(num_cuenta, nombre, apellido, fecha_nacimiento);
      user.setNip(uint.Parse(nip));
      usuarios.Add(user);

      WriteLine("El usuario se ha creado satisfactoriamente");
    }
  }
}