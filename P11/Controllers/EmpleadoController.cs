using Microsoft.AspNetCore.Mvc;

namespace P11.Controllers;

[ApiController]
[Route("api/[controller]")]

public class EmpleadoController : ControllerBase
{
  #region Get
  [HttpGet(Name = "GetAllEmpleados")]
  public IActionResult GetAllEmpleados()
  {
    var empleados = new Empleado().GetAll();

    if (empleados == null)
    {
      return StatusCode(500);
    }

    return Ok(empleados);
  }

  [HttpGet("{id}", Name = "GetEmpleado")]
  public IActionResult Get(int id)
  {
    var empleado = new Empleado().Get(id);

    if (empleado == null)
    {
      return NotFound();
    }
    return Ok(empleado);
  }

  [HttpGet("{id}/prestamos", Name = "GetAllPrestamos")]
  public IActionResult GetAllPrestamos(int id)
  {
    var empleados = new EmpleadoFunctions().UltimosPrestamos(id);

    if (empleados == null)
    {
      return StatusCode(500);
    }

    return Ok(empleados);
  }

  [HttpGet("{id}/prestamo", Name = "GetPrestamo")]
  public IActionResult GetPrestamo(int id)
  {
    var empleado = new EmpleadoFunctions().UltimoPrestamo(id);

    if (empleado == null)
    {
      return NotFound();
    }
    return Ok(empleado);
  }
  #endregion

  [HttpPost(Name = "CreateEmpleado")]
  public IActionResult Create([FromBody] EmpleadoCreate empleado)
  {
    if (empleado == null)
    {
      return BadRequest();
    }

    if (!ModelState.IsValid)
    {
      return BadRequest(ModelState);
    }

    Empleado newEmpleado = new EmpleadoCreate().Create(empleado);


    if (newEmpleado.Id == 0)
    {
      return StatusCode(500);
    }

    return CreatedAtRoute("GetEmpleado", new { id = newEmpleado.Id }, newEmpleado);
  }

  [HttpPut("{id}", Name = "UpdateEmpleado")]
  public IActionResult Update(int id, [FromBody] EmpleadoUpdate empleado)
  {
    if (empleado == null)
    {
      return BadRequest();
    }

    if (!ModelState.IsValid)
    {
      return BadRequest(ModelState);
    }

    Empleado newEmpleado = new EmpleadoUpdate().Update(id, empleado);

    if (newEmpleado == null)
    {
      return NotFound();
    }

    return Ok(newEmpleado);
  }

  [HttpDelete("{id}", Name = "DeleteEmpleado")]
  public IActionResult Delete(int id)
  {
    var empleado = new Empleado().Get(id);

    if (empleado == null)
    {
      return NotFound();
    }

    var deleted = new Empleado().Delete(id);

    if (deleted == null)
    {
      return StatusCode(500);
    }

    return StatusCode(200, deleted);
  }
}