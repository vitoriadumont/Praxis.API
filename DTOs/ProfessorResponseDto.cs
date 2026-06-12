namespace Praxis.API.DTOs;

public class ProfessorResponseDto
{
    public int Id { get; set; }

    public required string Nome { get; set; }

    public required string Email { get; set; }

    public required string Departamento { get; set; }
}