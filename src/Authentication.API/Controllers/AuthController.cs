using Authentication.API.Models;
using Authentication.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Authentication.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;
    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] Usuario usuario)
    {
        var token = _authService.Authenticate(usuario.UserName, usuario.Password);

        if (token == null)
            return Unauthorized("Credenciais inválidas");

        return Ok(new { Token = token });
    }
}
