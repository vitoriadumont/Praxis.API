using Praxis.API.DTOs;

namespace Praxis.API.Services;

public interface IAlunoService
{
    Task<IEnumerable<AlunoResponseDto>> GetAllAsync();

    Task<AlunoResponseDto?> GetByIdAsync(int id);

    Task<AlunoResponseDto> CreateAsync(CreateAlunoDto dto);

    Task<bool> UpdateAsync(int id, CreateAlunoDto dto);

    Task<bool> DeleteAsync(int id);
}