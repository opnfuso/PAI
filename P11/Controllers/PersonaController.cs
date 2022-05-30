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
}