using System;
using static System.Console;
namespace P7
{
  public partial class Program
  {
    static void crear_gerente()
    {
      WriteLine();
      Write("\nIngresa el numero de gerente : ");
      string? ngerente = ReadLine();
      uint num_gerente = uint.Parse(ngerente);
      Write("Ingresa la contraseña maestra : ");
      string? masterPass = ReadLine();
      WriteLine();
      Gerente gerente = new Gerente(num_gerente);
      gerente.setMasterPassword(masterPass);
      gerentes.Add(gerente);

      WriteLine("El gerente se ha creado satisfactoriamente");
    }
  }
}