namespace Praxis.API.DTOs;

public class LoginResponseDto
{
    public required string Token { get; set; }

    public required string Nome { get; set; }

    public required string Email { get; set; }
}