using Praxis.API.DTOs;

namespace Praxis.API.Services;

public interface IProfessorService
{
    Task<IEnumerable<ProfessorResponseDto>> GetAllAsync();

    Task<ProfessorResponseDto?> GetByIdAsync(int id);

    Task<ProfessorResponseDto> CreateAsync(CreateProfessorDto dto);

    Task<bool> UpdateAsync(int id, CreateProfessorDto dto);

    Task<bool> DeleteAsync(int id);
}