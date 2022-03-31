using System;
using static System.Console;
namespace P7
{
  public partial class Program
  {
    static void crear_usuario()
    {
      try
      {
        Write("\nIngresa el numero de cuenta : ");
        string? ncuenta = ReadLine();
        uint num_cuenta = uint.Parse(ncuenta);

        IEnumerable<Usuario> usuarios_lista = Program.usuarios.Where(usuario => usuario.num_cuenta == num_cuenta);
        if (usuarios_lista.LongCount() != 0)
        {
          throw new Exception("Ese numero de cuenta ya existe");
        }

        Write("Ingresa el nombre : ");
        string? nombre = ReadLine();
        Write("Ingresa el apellido : ");
        string? apellido = ReadLine();
        Write("Ingresa el fecha de nacimiento : ");
        string? fecha = ReadLine();
        Write("Ingresa el nip : ");
        string? nip = ReadLine();
        uint nip_user = uint.Parse(nip);
        WriteLine();
        DateOnly fecha_nacimiento = DateOnly.Parse(fecha);
        Usuario user = new Usuario(num_cuenta, nombre, apellido, fecha_nacimiento, nip_user);
        usuarios.Add(user);
        UsuarioJsonSerialization(usuarios);

        WriteLine("El usuario se ha creado satisfactoriamente");
      }
      catch (System.Exception error)
      {
        WriteLine(error.Message);
        return;
      }
    }
  }
}