using Microsoft.EntityFrameworkCore;
using Praxis.API.Data;
using Praxis.API.Models;

namespace Praxis.API.Repositories;

public class AlunoRepository : IAlunoRepository
{
    private readonly AppDbContext _context;

    public AlunoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Aluno>> GetAllAsync()
    {
        return await _context.Alunos.ToListAsync();
    }

    public async Task<Aluno?> GetByIdAsync(int id)
    {
        return await _context.Alunos.FindAsync(id);
    }

    public async Task<Aluno> CreateAsync(Aluno aluno)
    {
        _context.Alunos.Add(aluno);

        await _context.SaveChangesAsync();

        return aluno;
    }

    public async Task UpdateAsync(Aluno aluno)
    {
        _context.Alunos.Update(aluno);

        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Aluno aluno)
    {
        _context.Alunos.Remove(aluno);

        await _context.SaveChangesAsync();
    }
}