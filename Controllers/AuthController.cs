using Microsoft.AspNetCore.Mvc;
using Praxis.API.DTOs;
using Praxis.API.Services;

namespace Praxis.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _service;

    public AuthController(IAuthService service)
    {
        _service = service;
    }

    [HttpPost("login")]
    public async Task<ActionResult<LoginResponseDto>> Login(LoginDto dto)
    {
        var result = await _service.LoginAsync(dto);

        if (result == null)
        {
            return Unauthorized(new
            {
                message = "E-mail ou senha inválidos."
            });
        }

        return Ok(result);
    }
}