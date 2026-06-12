namespace Praxis.API.DTOs;

public class DisciplinaResponseDto
{
    public int Id { get; set; }

    public required string Nome { get; set; }

    public required string Codigo { get; set; }

    public int ProfessorId { get; set; }

    public required string NomeProfessor { get; set; }
}