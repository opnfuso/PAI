using Microsoft.AspNetCore.Mvc;

namespace P11.Controllers;

[ApiController]
[Route("api/[controller]")]

public class EmpleadoController : ControllerBase
{
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
    var empleados = new Empleado().UltimosPrestamos(id);

    if (empleados == null)
    {
      return StatusCode(500);
    }

    return Ok(empleados);
  }

  [HttpGet("{id}/prestamo", Name = "GetPrestamo")]
  public IActionResult GetPrestamo(int id)
  {
    var empleado = new Empleado().UltimoPrestamo(id);

    if (empleado == null)
    {
      return NotFound();
    }
    return Ok(empleado);
  }
}