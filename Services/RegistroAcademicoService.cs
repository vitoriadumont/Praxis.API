using Praxis.API.DTOs;
using Praxis.API.Models;
using Praxis.API.Repositories;

namespace Praxis.API.Services;

public class RegistroAcademicoService
    : IRegistroAcademicoService
{
    private readonly IRegistroAcademicoRepository _repository;

    public RegistroAcademicoService(
        IRegistroAcademicoRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<RegistroAcademicoResponseDto>>
        GetAllAsync()
    {
        var registros = await _repository.GetAllAsync();

        return registros.Select(r => new RegistroAcademicoResponseDto
        {
            Id = r.Id,
            Aluno = r.Aluno.Nome,
            Disciplina = r.Disciplina.Nome,
            Professor = r.Disciplina.Professor.Nome,
            Nota = r.Nota,
            Frequencia = r.Frequencia,
            Status = CalcularStatus(r.Nota, r.Frequencia)
        });
    }

    public async Task<RegistroAcademicoResponseDto?>
        GetByIdAsync(int id)
    {
        var r = await _repository.GetByIdAsync(id);

        if (r == null)
        {
            return null;
        }

        return new RegistroAcademicoResponseDto
        {
            Id = r.Id,
            Aluno = r.Aluno.Nome,
            Disciplina = r.Disciplina.Nome,
            Professor = r.Disciplina.Professor.Nome,
            Nota = r.Nota,
            Frequencia = r.Frequencia,
            Status = CalcularStatus(r.Nota, r.Frequencia)
        };
    }

    public async Task<RegistroAcademicoResponseDto>
        CreateAsync(CreateRegistroAcademicoDto dto)
    {
        var registro = new RegistroAcademico
        {
            AlunoId = dto.AlunoId,
            DisciplinaId = dto.DisciplinaId,
            Nota = dto.Nota,
            Frequencia = dto.Frequencia
        };

        await _repository.CreateAsync(registro);

        registro = await _repository.GetByIdAsync(registro.Id);

        return new RegistroAcademicoResponseDto
        {
            Id = registro!.Id,
            Aluno = registro.Aluno.Nome,
            Disciplina = registro.Disciplina.Nome,
            Professor = registro.Disciplina.Professor.Nome,
            Nota = registro.Nota,
            Frequencia = registro.Frequencia,
            Status = CalcularStatus(
                registro.Nota,
                registro.Frequencia)
        };
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var registro = await _repository.GetByIdAsync(id);

        if (registro == null)
        {
            return false;
        }

        await _repository.DeleteAsync(registro);

        return true;
    }

    private static string CalcularStatus(
        decimal nota,
        decimal frequencia)
    {
        return nota >= 7 && frequencia >= 75
            ? "Aprovado"
            : "Reprovado";
    }
}