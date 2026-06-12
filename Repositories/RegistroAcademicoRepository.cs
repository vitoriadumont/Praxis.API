using Microsoft.EntityFrameworkCore;
using Praxis.API.Data;
using Praxis.API.Models;

namespace Praxis.API.Repositories;

public class RegistroAcademicoRepository
    : IRegistroAcademicoRepository
{
    private readonly AppDbContext _context;

    public RegistroAcademicoRepository(
        AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<RegistroAcademico>> GetAllAsync()
    {
        return await _context.RegistrosAcademicos
            .Include(r => r.Aluno)
            .Include(r => r.Disciplina)
                .ThenInclude(d => d.Professor)
            .ToListAsync();
    }

    public async Task<RegistroAcademico?> GetByIdAsync(int id)
    {
        return await _context.RegistrosAcademicos
            .Include(r => r.Aluno)
            .Include(r => r.Disciplina)
                .ThenInclude(d => d.Professor)
            .FirstOrDefaultAsync(r => r.Id == id);
    }

    public async Task<RegistroAcademico> CreateAsync(
        RegistroAcademico registro)
    {
        _context.RegistrosAcademicos.Add(registro);

        await _context.SaveChangesAsync();

        return registro;
    }

    public async Task DeleteAsync(RegistroAcademico registro)
    {
        _context.RegistrosAcademicos.Remove(registro);

        await _context.SaveChangesAsync();
    }
}