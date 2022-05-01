using System;
using static System.Console;
namespace P10
{
  class Program
  {
    static void Main(string[] args)
    {
      Write("Ingrese el numero de personas: ");
      string? res = ReadLine();
      int personas = int.Parse(res!);

      Write("Ingrese el numero de bolsitas: ");
      res = ReadLine();
      int bolsitas = int.Parse(res!);

      Write("Ingrese el numero de items por bolsita: ");
      res = ReadLine();
      int items = int.Parse(res!);

      if ((bolsitas * items) % personas != 0)
      {
        WriteLine("No se puede hacer la distribucion");
      }
      else if (bolsitas < items)
      {
        WriteLine("Tienes que haber mas bolsitas que items");
      }
      else if (personas < items)
      {
        WriteLine("Tienes que haber mas o igual personas que items por bolsita");
      }
      else
      {
        var bolsas = new List<List<int>>();
        var bolsa = new List<int>();

        for (int i = 0; i < bolsitas; i++)
        {
          for (int j = 0; j < items; j++)
          {
            var rand = new Random();
            int r = rand.Next(0, bolsitas * items);
            bolsa.Add(r);
          }
          bolsas.Add(bolsa);
          bolsa = new List<int>();
        }

        var personas_bolsas = new List<List<int>>();
        var personas_bolsa = new List<int>();

        var personas_elecciones = new List<List<int>>();
        var personas_eleccion = new List<int>();

        int nItems = (items * bolsitas) / personas;

        var hashmap = new Dictionary<int, int>();
        for (int i = 0; i < bolsitas; i++)
        {
          hashmap.Add(i, 0);
        }

        if (personas == 2)
        {
          personas_elecciones = distribute2(personas, nItems, bolsitas, personas_eleccion, hashmap, personas_elecciones, items);
        }
        else
        {
          personas_elecciones = distribute(personas, nItems, bolsitas, personas_eleccion, hashmap, personas_elecciones, items);
        }

        for (int i = 0; i < personas_elecciones.Count; i++)
        {
          personas_bolsa = new List<int>();
          Write("Persona " + (i + 1) + ":");
          for (int j = 0; j < personas_elecciones[i].Count; j++)
          {
            Random rand = new Random();
            int r = rand.Next(0, bolsas[personas_elecciones[i][j]].Count);

            personas_bolsa.Add(bolsas[personas_elecciones[i][j]].ElementAt(r));
            Write(" " + bolsas[personas_elecciones[i][j]].ElementAt(r));
            bolsas[personas_elecciones[i][j]].RemoveAt(r);
          }
          WriteLine();
          personas_bolsas.Add(personas_bolsa);
        }
      }
    }

    static List<List<int>> distribute2(int personas, int nItems, int bolsitas, List<int> personas_eleccion, Dictionary<int, int> hashmap, List<List<int>> personas_elecciones, int items)
    {
      int num;
      for (int j = 0; j < personas; j++)
      {
        for (int i = 0; i < nItems; i++)
        {
          do
          {
            num = new Random().Next(0, bolsitas);
          } while (personas_eleccion.Contains(num) == true || (hashmap[num] < items) == false);
          hashmap[num]++;
          personas_eleccion.Add(num);
        }
        personas_elecciones.Add(personas_eleccion);
        personas_eleccion = new List<int>();
      }

      return personas_elecciones;
    }

    static List<List<int>> distribute(int personas, int nItems, int bolsitas, List<int> personas_eleccion, Dictionary<int, int> hashmap, List<List<int>> personas_elecciones, int items)
    {
      int num;
      for (int j = 0; j < personas - 2; j++)
      {
        for (int i = 0; i < nItems; i++)
        {
          do
          {
            num = new Random().Next(0, bolsitas);
          } while (personas_eleccion.Contains(num) == true || (hashmap[num] < items) == false);
          hashmap[num]++;
          personas_eleccion.Add(num);
        }
        personas_elecciones.Add(personas_eleccion);
        personas_eleccion = new List<int>();
      }

      // Get the key of the lowest element in hashmap
      int min = 0;
      bool flag = false;

      foreach (var val in hashmap.Values)
      {
        if (flag == false)
        {
          min = val;
          flag = true;
        }
        else if (val < min)
        {
          min = val;
        }
      }

      // Count the number of elements in hashmap with the lowest value
      int count = 0;
      foreach (var val in hashmap.Values)
      {
        if (val == min)
        {
          count++;
        }
      }

      // Force the random number generator to generate the number with the lowest rate in the hashmap
      for (int j = personas - 2; j < personas - 1; j++)
      {
        for (int i = 0; i < nItems; i++)
        {
          if (count == 0)
          {
            do
            {
              num = new Random().Next(0, bolsitas);
            } while (personas_eleccion.Contains(num) == true || (hashmap[num] < items) == false);
            hashmap[num]++;
          }
          else
          {

            do
            {
              num = new Random().Next(0, bolsitas);
            } while (personas_eleccion.Contains(num) == true || hashmap[num] != min);
            hashmap[num]++;
            count--;
          }
          personas_eleccion.Add(num);
        }
        personas_elecciones.Add(personas_eleccion);
        personas_eleccion = new List<int>();
      }

      // Fill the rest of the elections randomly
      for (int j = personas - 1; j < personas; j++)
      {
        for (int i = 0; i < nItems; i++)
        {
          do
          {
            num = new Random().Next(0, bolsitas);
          } while (personas_eleccion.Contains(num) == true || (hashmap[num] < items) == false);
          hashmap[num]++;
          personas_eleccion.Add(num);
        }
        personas_elecciones.Add(personas_eleccion);
        personas_eleccion = new List<int>();
      }

      return personas_elecciones;
    }
  }
}