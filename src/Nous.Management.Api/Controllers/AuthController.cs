using Microsoft.AspNetCore.Mvc;
using Nous.Management.Api.Models;
using Nous.Management.Api.Services;

namespace Nous.Management.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("login")]
    [ProducesResponseType(typeof(LoginResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public IActionResult Login([FromBody] LoginRequest request)
    {
        var response = _authService.Login(request);
        if (response is null)
            return Unauthorized(new { message = "Usuário ou senha inválidos." });

        return Ok(response);
    }
}
