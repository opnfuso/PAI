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

  [HttpPost(Name = "CreatePersona")]
  public IActionResult Create([FromBody] PersonaCreate persona)
  {
    if (persona == null)
    {
      return BadRequest();
    }

    if (!ModelState.IsValid)
    {
      return BadRequest(ModelState);
    }

    var PersonaValidations = new PersonaValidations();

    bool curp = PersonaValidations.VerifyCURP(persona.Curp, persona.PrimerNombre, persona.PrimerApellido, persona.SegundoApellido, persona.FechaNacimiento);

    if (curp == false)
    {
      var res = new
      {
        message = "La CURP no es valida"
      };
      return BadRequest(res);
    }

    var personaCreated = new PersonaCreate().Create(persona);

    if (personaCreated == null)
    {
      return StatusCode(500);
    }

    return CreatedAtRoute("GetPersona", new { id = personaCreated.Id }, personaCreated);
  }

  // [AcceptVerbs("POST", "PUT")]
}