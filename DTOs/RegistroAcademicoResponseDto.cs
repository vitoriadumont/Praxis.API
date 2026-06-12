namespace Praxis.API.DTOs;

public class RegistroAcademicoResponseDto
{
    public int Id { get; set; }

    public required string Aluno { get; set; }

    public required string Disciplina { get; set; }

    public required string Professor { get; set; }

    public decimal Nota { get; set; }

    public decimal Frequencia { get; set; }

    public required string Status { get; set; }
}