using Microsoft.AspNetCore.Mvc;
using System.Web.Http.Cors;
namespace P11.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsuarioController : ControllerBase
{
    //   private readonly ILogger<UsuarioController> _logger;

    //   public UsuarioController(ILogger<UsuarioController> logger)
    //   {
    //     _logger = logger;
    //   }

    #region Get
    [HttpGet(Name = "GetAllUsers")]
    public IActionResult GetAllUsers()
    {
        var users = new Usuario().GetAll();

        // if (users == null)
        // {
        //   return StatusCode(500);
        // }

        return Ok(users);
    }

    [HttpGet("{id}", Name = "GetUsuario")]
    public IActionResult Get(long id)
    {
        var user = new Usuario().Get(id);

        if (user == null)
        {
            return NotFound();
        }
        return Ok(user);
    }

    [HttpGet("{id}/prestamo", Name = "GetPrestamoActivo")]
    public IActionResult GetPrestamoActivo(long id)
    {
        var prestamo = new Usuario().GetActivePrestamo(id);

        if (prestamo == null)
        {
            var res = new
            {
                message = "No tiene prestamos activos",
            };
            return NotFound(res);
        }

        return Ok(prestamo);
    }

    [HttpGet("{id}/historial", Name = "GetHistorial")]
    public IActionResult GetHistorial(long id)
    {
        var prestamo = new Usuario().GetPayHistory(id);

        if (prestamo == null)
        {
            var res = new
            {
                message = "No tiene pagos",
            };

            return NotFound(res);
        }

        return Ok(prestamo);
    }
    [EnableCors(origins: "http://localhost:5500", headers: "*", methods: "*")]
    [HttpGet("lastPrestamo", Name = "GetUsersLastPrestamo")]
    public IActionResult GetUsersLastPrestamo()
    {
        var prestamos = new Usuario().GetListOfUsersWithLastPrestamo();

        if (prestamos == null)
        {
            var res = new
            {
                message = "No hay usuarios con prestamos",
            };

            return NotFound(res);
        }
        return Ok(prestamos);
    }

    [HttpGet("notEnoughMoney", Name = "GetUsersNotEnoughMoney")]
    public IActionResult GetUsersNotEnoughMoney()
    {
        var prestamos = new Usuario().GetListOfUserWithNotEnoughMoney();

        if (prestamos == null)
        {
            var res = new
            {
                message = "No hay usuarios con insuficiente dinero",
            };

            return NotFound(res);
        }
        return Ok(prestamos);
    }
    #endregion
}

