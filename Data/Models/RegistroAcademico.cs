namespace Praxis.API.Models;

public class RegistroAcademico
{
    public int Id { get; set; }

    public int AlunoId { get; set; }

    public Aluno Aluno { get; set; } = null!;

    public int DisciplinaId { get; set; }

    public Disciplina Disciplina { get; set; } = null!;

    public decimal Nota { get; set; }

    public decimal Frequencia { get; set; }
}