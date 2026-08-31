using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Praxis.API.DTOs;
using Praxis.API.Services;

namespace Praxis.API.Controllers;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class RegistroAcademicoController : ControllerBase
{
    private readonly IRegistroAcademicoService _service;

    public RegistroAcademicoController(
        IRegistroAcademicoService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<
        IEnumerable<RegistroAcademicoResponseDto>>> GetAll()
    {
        return Ok(await _service.GetAllAsync());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<
        RegistroAcademicoResponseDto>> GetById(int id)
    {
        var registro = await _service.GetByIdAsync(id);

        if (registro == null)
        {
            return NotFound();
        }

        return Ok(registro);
    }

    [HttpPost]
    public async Task<ActionResult<
        RegistroAcademicoResponseDto>> Create(
        CreateRegistroAcademicoDto dto)
    {
        var registro = await _service.CreateAsync(dto);

        return CreatedAtAction(
            nameof(GetById),
            new { id = registro.Id },
            registro);
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