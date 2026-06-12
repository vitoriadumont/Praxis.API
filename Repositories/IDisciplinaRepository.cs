using Praxis.API.Models;

namespace Praxis.API.Repositories;

public interface IDisciplinaRepository
{
    Task<IEnumerable<Disciplina>> GetAllAsync();

    Task<Disciplina?> GetByIdAsync(int id);

    Task<Disciplina> CreateAsync(Disciplina disciplina);

    Task UpdateAsync(Disciplina disciplina);

    Task DeleteAsync(Disciplina disciplina);
}