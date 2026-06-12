using Microsoft.AspNetCore.Mvc;
using Praxis.API.DTOs;
using Praxis.API.Services;

namespace Praxis.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DisciplinasController : ControllerBase
{
    private readonly IDisciplinaService _service;

    public DisciplinasController(IDisciplinaService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<DisciplinaResponseDto>>> GetAll()
    {
        var disciplinas = await _service.GetAllAsync();

        return Ok(disciplinas);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<DisciplinaResponseDto>> GetById(int id)
    {
        var disciplina = await _service.GetByIdAsync(id);

        if (disciplina == null)
        {
            return NotFound(new
            {
                message = "Disciplina não encontrada."
            });
        }

        return Ok(disciplina);
    }

    [HttpPost]
    public async Task<ActionResult<DisciplinaResponseDto>> Create(
        CreateDisciplinaDto dto)
    {
        var disciplina = await _service.CreateAsync(dto);

        return CreatedAtAction(
            nameof(GetById),
            new { id = disciplina.Id },
            disciplina);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(
        int id,
        CreateDisciplinaDto dto)
    {
        var updated = await _service.UpdateAsync(id, dto);

        if (!updated)
        {
            return NotFound(new
            {
                message = "Disciplina não encontrada."
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
                message = "Disciplina não encontrada."
            });
        }

        return NoContent();
    }
}