using Praxis.API.DTOs;

namespace Praxis.API.Services;

public interface IDisciplinaService
{
    Task<IEnumerable<DisciplinaResponseDto>> GetAllAsync();

    Task<DisciplinaResponseDto?> GetByIdAsync(int id);

    Task<DisciplinaResponseDto> CreateAsync(CreateDisciplinaDto dto);

    Task<bool> UpdateAsync(int id, CreateDisciplinaDto dto);

    Task<bool> DeleteAsync(int id);
}