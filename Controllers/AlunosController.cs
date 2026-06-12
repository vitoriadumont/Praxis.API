using Microsoft.AspNetCore.Mvc;
using Praxis.API.DTOs;
using Praxis.API.Services;

namespace Praxis.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AlunosController : ControllerBase
{
    private readonly IAlunoService _service;

    public AlunosController(IAlunoService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<AlunoResponseDto>>> GetAll()
    {
        var alunos = await _service.GetAllAsync();

        return Ok(alunos);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<AlunoResponseDto>> GetById(int id)
    {
        var aluno = await _service.GetByIdAsync(id);

        if (aluno == null)
        {
            return NotFound(new
            {
                message = "Aluno não encontrado."
            });
        }

        return Ok(aluno);
    }

    [HttpPost]
    public async Task<ActionResult<AlunoResponseDto>> Create(
        CreateAlunoDto dto)
    {
        var aluno = await _service.CreateAsync(dto);

        return CreatedAtAction(
            nameof(GetById),
            new { id = aluno.Id },
            aluno);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(
        int id,
        CreateAlunoDto dto)
    {
        var updated = await _service.UpdateAsync(id, dto);

        if (!updated)
        {
            return NotFound(new
            {
                message = "Aluno não encontrado."
            });
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _service.DeleteAsync(id);

        if (!deleted)
        {
            return NotFound(new
            {
                message = "Aluno não encontrado."
            });
        }

        return NoContent();
    }
}