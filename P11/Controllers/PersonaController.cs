using Microsoft.AspNetCore.Mvc;

namespace P11.Controllers;

[ApiController]
[Route("api/[controller]")]

public class PersonaController : ControllerBase
{
  [HttpGet(Name = "GetAllPersonas")]
  public IActionResult GetAllPersonas()
  {
    var personas = new Persona().GetAll();

    if (personas == null)
    {
      return StatusCode(500);
    }

    return Ok(personas);
  }

  [HttpGet("{id}", Name = "GetPersona")]
  public IActionResult Get(int id)
  {
    var persona = new Persona().Get(id);

    if (persona == null)
    {
      return NotFound();
    }
    return Ok(persona);
  }

  [AcceptVerbs("POST", "PUT")]
  public IActionResult VerifyCURP(string CURP, string Pn, string Pa, string Sa, DateTime Nacimiento)
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
      if (flag == true)
      {
        return Ok("CURP Valida");
      }
      else
      {
        return BadRequest("CURP Invalida");
      }
  }

  public bool IsVocal(char vocal)
    {
      char[] vocales = { 'A', 'a', 'I', 'i', 'U', 'u', 'E', 'e', 'O', 'o' };
      return vocales.Contains(vocal);
    }
}