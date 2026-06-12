using Microsoft.EntityFrameworkCore;
using Praxis.API.Data;
using Praxis.API.Repositories;
using Praxis.API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

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

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();

app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();

app.Run();