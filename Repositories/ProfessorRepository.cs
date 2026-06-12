using Microsoft.EntityFrameworkCore;
using Praxis.API.Data;
using Praxis.API.Models;

namespace Praxis.API.Repositories;

public class ProfessorRepository : IProfessorRepository
{
    private readonly AppDbContext _context;

    public ProfessorRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Professor>> GetAllAsync()
    {
        return await _context.Professores.ToListAsync();
    }

    public async Task<Professor?> GetByIdAsync(int id)
    {
        return await _context.Professores.FindAsync(id);
    }

    public async Task<Professor> CreateAsync(Professor professor)
    {
        _context.Professores.Add(professor);

        await _context.SaveChangesAsync();

        return professor;
    }

    public async Task UpdateAsync(Professor professor)
    {
        _context.Professores.Update(professor);

        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Professor professor)
    {
        _context.Professores.Remove(professor);

        await _context.SaveChangesAsync();
    }
}