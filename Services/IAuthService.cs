using Praxis.API.DTOs;

namespace Praxis.API.Services;

public interface IAuthService
{
    Task<LoginResponseDto?> LoginAsync(LoginDto dto);
}