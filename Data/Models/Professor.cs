namespace Praxis.API.Models;

public class Professor
{
    public int Id { get; set; }

    public required string Nome { get; set; }

    public required string Email { get; set; }

    public required string Departamento { get; set; }

    public List<Disciplina> Disciplinas { get; set; } = [];
}