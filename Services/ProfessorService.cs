using Praxis.API.DTOs;
using Praxis.API.Models;
using Praxis.API.Repositories;

namespace Praxis.API.Services;

public class ProfessorService : IProfessorService
{
    private readonly IProfessorRepository _repository;

    public ProfessorService(IProfessorRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<ProfessorResponseDto>> GetAllAsync()
    {
        var professores = await _repository.GetAllAsync();

        return professores.Select(p => new ProfessorResponseDto
        {
            Id = p.Id,
            Nome = p.Nome,
            Email = p.Email,
            Departamento = p.Departamento
        });
    }

    public async Task<ProfessorResponseDto?> GetByIdAsync(int id)
    {
        var professor = await _repository.GetByIdAsync(id);

        if (professor == null)
        {
            return null;
        }

        return new ProfessorResponseDto
        {
            Id = professor.Id,
            Nome = professor.Nome,
            Email = professor.Email,
            Departamento = professor.Departamento
        };
    }

    public async Task<ProfessorResponseDto> CreateAsync(CreateProfessorDto dto)
    {
        var professor = new Professor
        {
            Nome = dto.Nome,
            Email = dto.Email,
            Departamento = dto.Departamento
        };

        await _repository.CreateAsync(professor);

        return new ProfessorResponseDto
        {
            Id = professor.Id,
            Nome = professor.Nome,
            Email = professor.Email,
            Departamento = professor.Departamento
        };
    }

    public async Task<bool> UpdateAsync(int id, CreateProfessorDto dto)
    {
        var professor = await _repository.GetByIdAsync(id);

        if (professor == null)
        {
            return false;
        }

        professor.Nome = dto.Nome;
        professor.Email = dto.Email;
        professor.Departamento = dto.Departamento;

        await _repository.UpdateAsync(professor);

        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var professor = await _repository.GetByIdAsync(id);

        if (professor == null)
        {
            return false;
        }

        await _repository.DeleteAsync(professor);

        return true;
    }
}