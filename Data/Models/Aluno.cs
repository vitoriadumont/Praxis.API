namespace Praxis.API.Models;

public class Aluno
{
    public int Id { get; set; }

    public required string Nome { get; set; }

    public required string Matricula { get; set; }

    public required string Curso { get; set; }

    public List<RegistroAcademico> RegistrosAcademicos { get; set; } = [];
}