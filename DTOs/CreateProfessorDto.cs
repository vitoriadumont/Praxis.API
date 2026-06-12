namespace Praxis.API.DTOs;

public class CreateProfessorDto
{
    public required string Nome { get; set; }

    public required string Email { get; set; }

    public required string Departamento { get; set; }
}