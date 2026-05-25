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

    [HttpGet("{id}/components")]
    public async Task<IActionResult> GetComponents(int id)
    {
        var result = await service.GetComponents(id);

        if (result is null)
            return NotFound();

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        CreatePcRequestDto dto)
    {
        var result =
            await service.Create(dto);

        return Created(
            $"api/pcs/{result.Id}",
            result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(
        int id,
        UpdatePcRequestDto dto)
    {
        var updated =
            await service.Update(id, dto);

        if (!updated)
            return NotFound();

        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(
        int id)
    {
        var deleted =
            await service.Delete(id);

        if (!deleted)
            return NotFound();

        return NoContent();
    }
}