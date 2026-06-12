using Praxis.API.DTOs;
using Praxis.API.Models;
using Praxis.API.Repositories;

namespace Praxis.API.Services;

public class DisciplinaService : IDisciplinaService
{
    private readonly IDisciplinaRepository _repository;

    public DisciplinaService(IDisciplinaRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<DisciplinaResponseDto>> GetAllAsync()
    {
        var disciplinas = await _repository.GetAllAsync();

        return disciplinas.Select(d => new DisciplinaResponseDto
        {
            Id = d.Id,
            Nome = d.Nome,
            Codigo = d.Codigo,
            ProfessorId = d.ProfessorId,
            NomeProfessor = d.Professor.Nome
        });
    }

    public async Task<DisciplinaResponseDto?> GetByIdAsync(int id)
    {
        var disciplina = await _repository.GetByIdAsync(id);

        if (disciplina == null)
        {
            return null;
        }

        return new DisciplinaResponseDto
        {
            Id = disciplina.Id,
            Nome = disciplina.Nome,
            Codigo = disciplina.Codigo,
            ProfessorId = disciplina.ProfessorId,
            NomeProfessor = disciplina.Professor.Nome
        };
    }

    public async Task<DisciplinaResponseDto> CreateAsync(
        CreateDisciplinaDto dto)
    {
        var disciplina = new Disciplina
        {
            Nome = dto.Nome,
            Codigo = dto.Codigo,
            ProfessorId = dto.ProfessorId
        };

        await _repository.CreateAsync(disciplina);

        disciplina = await _repository.GetByIdAsync(disciplina.Id);

        return new DisciplinaResponseDto
        {
            Id = disciplina!.Id,
            Nome = disciplina.Nome,
            Codigo = disciplina.Codigo,
            ProfessorId = disciplina.ProfessorId,
            NomeProfessor = disciplina.Professor.Nome
        };
    }

    public async Task<bool> UpdateAsync(
        int id,
        CreateDisciplinaDto dto)
    {
        var disciplina = await _repository.GetByIdAsync(id);

        if (disciplina == null)
        {
            return false;
        }

        disciplina.Nome = dto.Nome;
        disciplina.Codigo = dto.Codigo;
        disciplina.ProfessorId = dto.ProfessorId;

        await _repository.UpdateAsync(disciplina);

        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var disciplina = await _repository.GetByIdAsync(id);

        if (disciplina == null)
        {
            return false;
        }

        await _repository.DeleteAsync(disciplina);

        return true;
    }
}