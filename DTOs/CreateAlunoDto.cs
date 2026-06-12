namespace Praxis.API.DTOs;

public class CreateAlunoDto
{
    public required string Nome { get; set; }

    public required string Matricula { get; set; }

    public required string Curso { get; set; }
}