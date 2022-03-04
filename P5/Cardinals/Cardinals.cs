namespace Cardinals;
public class Cardinal
{
  public string cardinals(int num)
  {

    if (num % 10 == 1 && num != 11)
    {
      return ($"{num}st");
    }
    else if (num % 10 == 2)
    {
      return ($"{num}nd");
    }
    else if (num % 10 == 3)
    {
      return ($"{num}rd");
    }
    else if (num == 11)
    {
      return ($"{num}th");
    }
    else
    {
      return ($"{num}th");
    }
  }

  public string[] runCardinals(string num)
  {
    try
    {
      int res = int.Parse(num);

      if (res < 0)
      {
        throw new Exception("No numeros negativos");
      }

      string[] ret = new string[res];

      for (int i = 1; i <= res; i++)
      {
        ret[i - 1] = cardinals(i);
      }

      return ret;
    }
    catch (FormatException)
    {
      string[] arr = { "No se puede parsear" };
      return (arr);
    }
    catch (Exception ex)
    {
      string[] arr = { ex.Message };
      return (arr);
    }

  }
}
