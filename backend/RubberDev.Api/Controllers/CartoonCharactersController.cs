using Microsoft.AspNetCore.Mvc;
using RubberDev.Brokers;
using RubberDev.Models;

namespace RubberDev.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CartoonCharactersController : ControllerBase
{
    private readonly IStorageBroker storageBroker;

    public CartoonCharactersController(IStorageBroker storageBroker)
    {
        this.storageBroker = storageBroker;
    }

    [HttpPost]
    public async ValueTask<ActionResult<CartoonCharacter>> Post(CartoonCharacter character) =>
        Ok(await storageBroker.InsertCartoonCharacterAsync(character));

    [HttpGet]
    public ActionResult<IQueryable<CartoonCharacter>> Get() =>
        Ok(storageBroker.SelectAllCartoonCharacters());

    [HttpGet("{id}")]
    public async ValueTask<ActionResult<CartoonCharacter>> GetById(Guid id) =>
        Ok(await storageBroker.SelectCartoonCharacterByIdAsync(id));

    [HttpPut]
    public async ValueTask<ActionResult<CartoonCharacter>> Put(CartoonCharacter character) =>
        Ok(await storageBroker.UpdateCartoonCharacterAsync(character));

    [HttpDelete("{id}")]
    public async ValueTask<ActionResult> Delete(Guid id)
    {
        await storageBroker.DeleteCartoonCharacterAsync(id);
        return NoContent();
    }
}