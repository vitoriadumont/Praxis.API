using Praxis.API.Models;

namespace Praxis.API.Repositories;

public interface IProfessorRepository
{
    Task<IEnumerable<Professor>> GetAllAsync();

    Task<Professor?> GetByIdAsync(int id);

    Task<Professor> CreateAsync(Professor professor);

    Task UpdateAsync(Professor professor);

    Task DeleteAsync(Professor professor);
}