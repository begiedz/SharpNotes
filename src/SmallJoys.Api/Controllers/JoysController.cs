using SmallJoys.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using SmallJoys.Application.Abstractions;

namespace SmallJoys.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class JoysController(IJoyRepository repo) : ControllerBase
{

    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await repo.GetAllAsync());

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        var joy = await repo.GetByIdAsync(id);

        return joy is null ? NotFound() : Ok(joy);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody]Joy joy)
    {
        var created = await repo.AddAsync(joy);
        return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] Joy joy)
    {
        if (id != joy.Id)
            return BadRequest();

        return await repo.UpdateAsync(joy) ? NoContent() : NotFound();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id) =>
        await repo.DeleteAsync(id) ? NoContent() : NotFound();
}
