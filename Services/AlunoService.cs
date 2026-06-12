using Praxis.API.DTOs;
using Praxis.API.Models;
using Praxis.API.Repositories;

namespace Praxis.API.Services;

public class AlunoService : IAlunoService
{
    private readonly IAlunoRepository _repository;

    public AlunoService(IAlunoRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<AlunoResponseDto>> GetAllAsync()
    {
        var alunos = await _repository.GetAllAsync();

        return alunos.Select(a => new AlunoResponseDto
        {
            Id = a.Id,
            Nome = a.Nome,
            Matricula = a.Matricula,
            Curso = a.Curso
        });
    }

    public async Task<AlunoResponseDto?> GetByIdAsync(int id)
    {
        var aluno = await _repository.GetByIdAsync(id);

        if (aluno == null)
        {
            return null;
        }

        return new AlunoResponseDto
        {
            Id = aluno.Id,
            Nome = aluno.Nome,
            Matricula = aluno.Matricula,
            Curso = aluno.Curso
        };
    }

    public async Task<AlunoResponseDto> CreateAsync(CreateAlunoDto dto)
    {
        var aluno = new Aluno
        {
            Nome = dto.Nome,
            Matricula = dto.Matricula,
            Curso = dto.Curso
        };

        await _repository.CreateAsync(aluno);

        return new AlunoResponseDto
        {
            Id = aluno.Id,
            Nome = aluno.Nome,
            Matricula = aluno.Matricula,
            Curso = aluno.Curso
        };
    }

    public async Task<bool> UpdateAsync(int id, CreateAlunoDto dto)
    {
        var aluno = await _repository.GetByIdAsync(id);

        if (aluno == null)
        {
            return false;
        }

        aluno.Nome = dto.Nome;
        aluno.Matricula = dto.Matricula;
        aluno.Curso = dto.Curso;

        await _repository.UpdateAsync(aluno);

        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var aluno = await _repository.GetByIdAsync(id);

        if (aluno == null)
        {
            return false;
        }

        await _repository.DeleteAsync(aluno);

        return true;
    }
}