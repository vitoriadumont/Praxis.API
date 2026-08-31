using Praxis.API.Models;

namespace Praxis.API.Repositories;

public interface IUsuarioRepository
{
    Task<Usuario?> GetByEmailAsync(string email);
}