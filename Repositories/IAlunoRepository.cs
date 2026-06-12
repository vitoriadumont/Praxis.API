using Praxis.API.Models;

namespace Praxis.API.Repositories;

public interface IAlunoRepository
{
    Task<IEnumerable<Aluno>> GetAllAsync();

    Task<Aluno?> GetByIdAsync(int id);

    Task<Aluno> CreateAsync(Aluno aluno);

    Task UpdateAsync(Aluno aluno);

    Task DeleteAsync(Aluno aluno);
}