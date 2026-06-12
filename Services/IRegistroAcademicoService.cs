using Praxis.API.DTOs;

namespace Praxis.API.Services;

public interface IRegistroAcademicoService
{
    Task<IEnumerable<RegistroAcademicoResponseDto>> GetAllAsync();

    Task<RegistroAcademicoResponseDto?> GetByIdAsync(int id);

    Task<RegistroAcademicoResponseDto> CreateAsync(
        CreateRegistroAcademicoDto dto);

    Task<bool> DeleteAsync(int id);
}