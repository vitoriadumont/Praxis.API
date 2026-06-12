namespace Praxis.API.Models;

public class Disciplina
{
    public int Id { get; set; }

    public required string Nome { get; set; }

    public required string Codigo { get; set; }

    public int ProfessorId { get; set; }

    public Professor Professor { get; set; } = null!;

    public List<RegistroAcademico> RegistrosAcademicos { get; set; } = [];
}