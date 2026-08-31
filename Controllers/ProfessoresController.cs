using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Praxis.API.DTOs;
using Praxis.API.Services;

namespace Praxis.API.Controllers;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class ProfessoresController : ControllerBase
{
    private readonly IProfessorService _service;

    public ProfessoresController(IProfessorService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProfessorResponseDto>>> GetAll()
    {
        var professores = await _service.GetAllAsync();

        return Ok(professores);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProfessorResponseDto>> GetById(int id)
    {
        var professor = await _service.GetByIdAsync(id);

        if (professor == null)
        {
            return NotFound();
        }

        return Ok(professor);
    }

    [HttpPost]
    public async Task<ActionResult<ProfessorResponseDto>> Create(
        CreateProfessorDto dto)
    {
        var professor = await _service.CreateAsync(dto);

        return CreatedAtAction(
            nameof(GetById),
            new { id = professor.Id },
            professor);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(
        int id,
        CreateProfessorDto dto)
    {
        var updated = await _service.UpdateAsync(id, dto);

        if (!updated)
        {
            return NotFound();
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _service.DeleteAsync(id);

        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }
}