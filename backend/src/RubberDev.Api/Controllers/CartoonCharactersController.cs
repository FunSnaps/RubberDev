using Microsoft.AspNetCore.Mvc;
using RubberDev.Application.UseCases;
using RubberDev.Domain.Entities;

namespace RubberDev.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CartoonCharactersController : ControllerBase
{
    private readonly ICartoonCharacterService _service;

    public CartoonCharactersController(ICartoonCharacterService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CartoonCharacter>>> GetAllAsync(
        CancellationToken cancellationToken)
    {
        return Ok(await _service
            .RetrieveAllCartoonCharactersAsync(cancellationToken));
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<CartoonCharacter>> GetByIdAsync(
        Guid id,
        CancellationToken cancellationToken)
    {
        try
        {
            var character = await _service
                .RetrieveCartoonCharacterByIdAsync(id, cancellationToken);
            return Ok(character);
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }

    [HttpPost]
    public async Task<ActionResult<CartoonCharacter>> CreateAsync(
        [FromBody] CartoonCharacter character,
        CancellationToken cancellationToken)
    {
        var created = await _service
            .AddCartoonCharacterAsync(character, cancellationToken);

        return CreatedAtAction(
            nameof(GetByIdAsync),
            new { id = created.Id },
            created);
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult<CartoonCharacter>> UpdateAsync(
        Guid id,
        [FromBody] CartoonCharacter character,
        CancellationToken cancellationToken)
    {
        if (id != character.Id)
            return BadRequest("Mismatched Id");

        var updated = await _service
            .ModifyCartoonCharacterAsync(character, cancellationToken);

        return Ok(updated);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteAsync(
        Guid id,
        CancellationToken cancellationToken)
    {
        var removed = await _service
            .RemoveCartoonCharacterAsync(id, cancellationToken);

        return removed ? NoContent() : NotFound();
    }
}