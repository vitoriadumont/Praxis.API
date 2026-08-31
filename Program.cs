using Microsoft.EntityFrameworkCore;
using Praxis.API.Data;
using Praxis.API.Repositories;
using Praxis.API.Services;
using Microsoft.AspNetCore.Identity;
using Praxis.API.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(
    options =>
        options.UseNpgsql(
            builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IAlunoRepository, AlunoRepository>();
builder.Services.AddScoped<IAlunoService, AlunoService>();
builder.Services.AddScoped<IProfessorRepository, ProfessorRepository>();
builder.Services.AddScoped<IProfessorService, ProfessorService>();
builder.Services.AddScoped<IDisciplinaRepository, DisciplinaRepository>();
builder.Services.AddScoped<IDisciplinaService, DisciplinaService>();
builder.Services.AddScoped<IRegistroAcademicoRepository, RegistroAcademicoRepository>();
builder.Services.AddScoped<IRegistroAcademicoService, RegistroAcademicoService>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirFront", policy =>
    {
        policy.WithOrigins("http://localhost:5173")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    if (!context.Usuarios.Any())
    {
        var hasher = new PasswordHasher<Usuario>();

        var usuario = new Usuario
        {
            Nome = "Coordenador",
            Email = "coordenador@praxis.edu.br",
            SenhaHash = string.Empty
        };

        usuario.SenhaHash = hasher.HashPassword(usuario, "123456");

        context.Usuarios.Add(usuario);

        context.SaveChanges();
    }
}

app.UseCors("PermitirFront");

app.UseSwagger();

app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();

app.Run();