using RubberDev.Models;
using RubberDev.Brokers;
using RubberDev.Services.Interfaces;

namespace RubberDev.Services;

public class CartoonCharacterService : ICartoonCharacterService
{
    private readonly IStorageBroker storageBroker;

    public CartoonCharacterService(IStorageBroker storageBroker) =>
        this.storageBroker = storageBroker;

    public async ValueTask<CartoonCharacter> AddCartoonCharacterAsync(CartoonCharacter character)
    {
        // TODO: add any business validations here
        return await this.storageBroker.InsertCartoonCharacterAsync(character);
    }

    public IQueryable<CartoonCharacter> RetrieveAllCartoonCharacters() =>
        this.storageBroker.SelectAllCartoonCharacters();

    public async ValueTask<CartoonCharacter> RetrieveCartoonCharacterByIdAsync(Guid characterId) =>
        await this.storageBroker
            .SelectCartoonCharacterByIdAsync(characterId);

    public async ValueTask<CartoonCharacter> ModifyCartoonCharacterAsync(CartoonCharacter character) =>
        await this.storageBroker.UpdateCartoonCharacterAsync(character);

    public async ValueTask<CartoonCharacter> RemoveCartoonCharacterAsync(Guid characterId) =>
        await this.storageBroker.DeleteCartoonCharacterAsync(characterId);
}