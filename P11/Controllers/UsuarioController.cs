using Microsoft.AspNetCore.Mvc;

namespace P11.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsuarioController : ControllerBase
{
    private readonly ILogger<UsuarioController> _logger;

    public UsuarioController(ILogger<UsuarioController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetUsuario")]
    public IEnumerable<Usuario> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new Usuario
        {
            NombreUsuario = $"Usuario {index}",
        })
        .ToArray();
    }
}
