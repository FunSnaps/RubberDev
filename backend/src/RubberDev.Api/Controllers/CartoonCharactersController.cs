using Microsoft.AspNetCore.Mvc;
using RubberDev.Application.Interfaces;
using RubberDev.Domain.Entities;

namespace RubberDev.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CartoonCharactersController : ControllerBase
{
    private readonly IStorageBroker storageBroker;

    public CartoonCharactersController(IStorageBroker storageBroker) =>
        this.storageBroker = storageBroker;
        
    [HttpGet]
    public IActionResult GetAll() =>
        Ok(this.storageBroker.SelectAllCartoonCharacters());
        
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var character = await this.storageBroker
            .SelectCartoonCharacterByIdAsync(id);

        if (character is null)
            return NotFound();

        return Ok(character);
    }
        
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CartoonCharacter character)
    {
        var created = await this.storageBroker
            .InsertCartoonCharacterAsync(character);

        return CreatedAtAction(nameof(GetById),
            new { id = created.Id }, created);
    }
        
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] CartoonCharacter character)
    {
        if (id != character.Id)
            return BadRequest("Mismatched Id");

        var updated = await this.storageBroker
            .UpdateCartoonCharacterAsync(character);

        return Ok(updated);
    }
        
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await this.storageBroker.DeleteCartoonCharacterAsync(id);
        return NoContent();
    }
}