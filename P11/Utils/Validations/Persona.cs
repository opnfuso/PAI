namespace P11
{
  public class PersonaValidations
  {
    public Boolean VerifyCURP(string CURP, string Pn, string Pa, string Sa, DateTime Nacimiento)
    {
      string fecha = Nacimiento.ToString("yyMMdd");
      bool flag = false;
      bool vocal = false;
      string voc = "1";
      if (CURP[0] == Pa[0])
      {
        flag = true;
        for (int i = 1; i < Pa.Length; i++)
        {
          if (IsVocal(Pa[i]) && vocal == false)
          {
            vocal = true;
            voc = Pa[i].ToString().ToUpper();
          }
        }
        if (CURP[1].ToString() == voc)
        {
          if (CURP[2] == Sa[0])
          {
            if (CURP[3] == Pn[0])
            {
              for (int i = 0; i < fecha.Length; i++)
              {
                if (!(CURP[i + 4] == fecha[i]))
                {
                  flag = false;
                }
              }
            }
            else
            {
              flag = false;
            }
          }
          else
          {
            flag = false;
          }
        }
        else
        {
          flag = false;
        }
      }

      return flag;
    }

    private bool IsVocal(char vocal)
    {
      char[] vocales = { 'A', 'a', 'I', 'i', 'U', 'u', 'E', 'e', 'O', 'o' };
      return vocales.Contains(vocal);
    }
  }
}