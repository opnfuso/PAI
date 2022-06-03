using Microsoft.AspNetCore.Mvc;

namespace P11.Controllers;

[ApiController]
[Route("api/[controller]")]

public class PrestamoController : ControllerBase
{
  [HttpGet(Name = "GetAllPrestamos")]
  public IActionResult GetAllPrestamos()
  {
    var prestamos = new Prestamo().GetAll();

    if (prestamos == null)
    {
      return StatusCode(500);
    }

    return Ok(prestamos);
  }

  [HttpGet("{id}", Name = "GetPrestamo")]
  public IActionResult GetPrestamo(int id)
  {
    var prestamo = new Prestamo().Get(id);

    if (prestamo == null)
    {
      return NotFound();
    }
    return Ok(prestamo);
  }

  [HttpPost(Name = "CreatePrestamo")]
  public IActionResult CreatePrestamo([FromBody] PrestamoCreate prestamo)
  {
    if (prestamo == null)
    {
      return BadRequest();
    }

    if (!ModelState.IsValid)
    {
      return BadRequest(ModelState);
    }

    // var prestamoCreated = new PrestamoCreate().Create(prestamo);

    // if (prestamoCreated == null)
    // {
    //   return StatusCode(500);
    // }

    // return CreatedAtRoute("GetPrestamo", new { id = prestamoCreated.Id }, prestamoCreated);

    return Ok();
  }
}