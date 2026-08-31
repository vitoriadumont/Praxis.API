using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Praxis.API.DTOs;
using Praxis.API.Models;
using Praxis.API.Repositories;

namespace Praxis.API.Services;

public class AuthService : IAuthService
{
    private readonly IUsuarioRepository _repository;
    private readonly IConfiguration _configuration;
    private readonly PasswordHasher<Usuario> _hasher = new();

    public AuthService(IUsuarioRepository repository, IConfiguration configuration)
    {
        _repository = repository;
        _configuration = configuration;
    }

    public async Task<LoginResponseDto?> LoginAsync(LoginDto dto)
    {
        var usuario = await _repository.GetByEmailAsync(dto.Email);

        if (usuario == null)
        {
            return null;
        }

        var result = _hasher.VerifyHashedPassword(usuario, usuario.SenhaHash, dto.Senha);

        if (result == PasswordVerificationResult.Failed)
        {
            return null;
        }

        var token = GerarToken(usuario);

        return new LoginResponseDto
        {
            Token = token,
            Nome = usuario.Nome,
            Email = usuario.Email
        };
    }

    private string GerarToken(Usuario usuario)
    {
        var jwtConfig = _configuration.GetSection("Jwt");

        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(jwtConfig["Key"]!));

        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
            new Claim(ClaimTypes.Name, usuario.Nome),
            new Claim(ClaimTypes.Email, usuario.Email)
        };

        var token = new JwtSecurityToken(
            issuer: jwtConfig["Issuer"],
            audience: jwtConfig["Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(
                double.Parse(jwtConfig["ExpiresInMinutes"]!)),
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}