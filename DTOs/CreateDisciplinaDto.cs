namespace Praxis.API.DTOs;

public class CreateDisciplinaDto
{
    public required string Nome { get; set; }

    public required string Codigo { get; set; }

    public int ProfessorId { get; set; }
}