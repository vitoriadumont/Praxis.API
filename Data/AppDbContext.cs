using Microsoft.EntityFrameworkCore;
using Praxis.API.Models;

namespace Praxis.API.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(
        DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Aluno> Alunos { get; set; }

    public DbSet<Professor> Professores { get; set; }

    public DbSet<Disciplina> Disciplinas { get; set; }
    public DbSet<RegistroAcademico> RegistrosAcademicos { get; set; }
}