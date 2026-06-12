namespace Praxis.API.DTOs;

public class AlunoResponseDto
{
    public int Id { get; set; }

    public required string Nome { get; set; }

    public required string Matricula { get; set; }

    public required string Curso { get; set; }
}