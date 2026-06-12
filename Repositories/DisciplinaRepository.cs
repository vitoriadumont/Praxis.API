using Microsoft.EntityFrameworkCore;
using Praxis.API.Data;
using Praxis.API.Models;

namespace Praxis.API.Repositories;

public class DisciplinaRepository : IDisciplinaRepository
{
    private readonly AppDbContext _context;

    public DisciplinaRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Disciplina>> GetAllAsync()
    {
        return await _context.Disciplinas
            .Include(d => d.Professor)
            .ToListAsync();
    }

    public async Task<Disciplina?> GetByIdAsync(int id)
    {
        return await _context.Disciplinas
            .Include(d => d.Professor)
            .FirstOrDefaultAsync(d => d.Id == id);
    }

    public async Task<Disciplina> CreateAsync(Disciplina disciplina)
    {
        _context.Disciplinas.Add(disciplina);

        await _context.SaveChangesAsync();

        return disciplina;
    }

    public async Task UpdateAsync(Disciplina disciplina)
    {
        _context.Disciplinas.Update(disciplina);

        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Disciplina disciplina)
    {
        _context.Disciplinas.Remove(disciplina);

        await _context.SaveChangesAsync();
    }
}