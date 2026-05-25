using ComputerManagement.DTOs.Pcs;
using ComputerManagement.Services;
using Microsoft.AspNetCore.Mvc;

namespace ComputerManagement.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PcsController(IPcService service) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await service.GetAll();

        return Ok(result);
    }

    [HttpGet("{id:int}/components")]
    public async Task<IActionResult> GetComponents([FromRoute] int id)
    {
        var result = await service.GetComponents(id);

        if (result is null)
            return NotFound();

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        [FromBody] CreatePcRequestDto dto)
    {
        var result =
            await service.Create(dto);

        return Created(
            $"api/pcs/{result.Id}",
            result);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(
        [FromRoute] int id,
        [FromBody] UpdatePcRequestDto dto)
    {
        var updated =
            await service.Update(id, dto);

        if (!updated)
            return NotFound();

        return Ok();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(
        [FromRoute] int id)
    {
        var deleted =
            await service.Delete(id);

        if (!deleted)
            return NotFound();

        return NoContent();
    }
}