using Microsoft.AspNetCore.Mvc;

namespace P11.Controllers;

[ApiController]
[Route("api/[controller]")]

public class GerenteController : ControllerBase
{
  [HttpGet(Name = "GetAllGerentes")]
  public IActionResult GetAllGerentes()
  {
    var gerentes = new Gerente().GetAll();

    if (gerentes == null)
    {
      return StatusCode(500);
    }

    return Ok(gerentes);
  }

  [HttpGet("{id}", Name = "GetGerente")]
  public IActionResult Get(int id)
  {
    var gerente = new Gerente().Get(id);

    if (gerente == null)
    {
      return NotFound();
    }
    return Ok(gerente);
  }

  [HttpGet("prestamosToAccept", Name = "GetPrestamosToAccept")]
  public IActionResult GetPrestamosToAccept()
  {
    var prestamos = new Gerente().GetPrestamosToAccept();

    if (prestamos == null)
    {
      return NotFound();
    }

    return Ok(prestamos);
  }

  [HttpGet("usuariosToAccept", Name = "GetUsuariosToAccept")]
  public IActionResult GetUsuariosToAccept()
  {
    var usuarios = new Gerente().GetUsuariosToAccept();

    if (usuarios == null)
    {
      return NotFound();
    }

    return Ok(usuarios);
  }

  [HttpPost(Name = "CreateGerente")]
  public IActionResult Create([FromBody] GerenteCreate gerente)
  {
    if (gerente == null)
    {
      return BadRequest();
    }

    if (!ModelState.IsValid)
    {
      return BadRequest(ModelState);
    }

    var gerenteCreated = new GerenteCreate().Create(gerente);

    if (gerenteCreated == null)
    {
      return StatusCode(500);
    }

    return CreatedAtRoute("GetGerente", new { id = gerenteCreated.Id }, gerenteCreated);
  }

  [HttpPut("{id}", Name = "UpdateGerente")]
  public IActionResult Update(int id, [FromBody] GerenteUpdate gerente)
  {
    if (gerente == null)
    {
      return BadRequest();
    }

    if (!ModelState.IsValid)
    {
      return BadRequest(ModelState);
    }

    var gerenteUpdated = new GerenteUpdate().Update(id, gerente);

    if (gerenteUpdated == null)
    {
      return StatusCode(500);
    }

    return Ok(gerenteUpdated);
  }
}