namespace Praxis.API.DTOs;

public class LoginDto
{
    public required string Email { get; set; }

    public required string Senha { get; set; }
}