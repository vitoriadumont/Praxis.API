namespace Praxis.API.DTOs;

public class CreateRegistroAcademicoDto
{
    public int AlunoId { get; set; }

    public int DisciplinaId { get; set; }

    public decimal Nota { get; set; }

    public decimal Frequencia { get; set; }
}