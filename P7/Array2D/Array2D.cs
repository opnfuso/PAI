namespace P7;
using System.Collections;
public class Array2D<T> : IEnumerable
{
  private T[,] _array;
  public Array2D(T[,] arr)
  {
    _array = arr;
  }

  public IEnumerator GetEnumerator()
  {
    for (int i = 0; i < _array.GetLength(0); i++)
    {
      for (int j = 0; j < _array.GetLength(1); j++)
      {
        yield return _array[i, j];
      }
    }
  }

  public T ElementAt(int x, int y)
  {
    return _array[x, y];
  }
}
