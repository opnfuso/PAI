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
}