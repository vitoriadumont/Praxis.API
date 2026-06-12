using Praxis.API.Models;

namespace Praxis.API.Repositories;

public interface IRegistroAcademicoRepository
{
    Task<IEnumerable<RegistroAcademico>> GetAllAsync();

    Task<RegistroAcademico?> GetByIdAsync(int id);

    Task<RegistroAcademico> CreateAsync(
        RegistroAcademico registro);

    Task DeleteAsync(RegistroAcademico registro);
}