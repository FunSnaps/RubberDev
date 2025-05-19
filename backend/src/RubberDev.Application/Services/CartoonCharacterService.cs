using RubberDev.Application.Interfaces;
using RubberDev.Domain.Entities;

namespace RubberDev.Application.Services;

public class CartoonCharacterService : ICartoonCharacterService
{
    private readonly IStorageBroker _storageBroker;

    public CartoonCharacterService(IStorageBroker storageBroker) =>
        this._storageBroker = storageBroker;

    public async ValueTask<CartoonCharacter> AddCartoonCharacterAsync(CartoonCharacter character)
    {
        // TODO: add any business validations here
        return await this._storageBroker.InsertCartoonCharacterAsync(character);
    }

    public IQueryable<CartoonCharacter> RetrieveAllCartoonCharacters() =>
        this._storageBroker.SelectAllCartoonCharacters();

    public async ValueTask<CartoonCharacter> RetrieveCartoonCharacterByIdAsync(Guid characterId) =>
        await this._storageBroker
            .SelectCartoonCharacterByIdAsync(characterId);

    public async ValueTask<CartoonCharacter> ModifyCartoonCharacterAsync(CartoonCharacter character) =>
        await this._storageBroker.UpdateCartoonCharacterAsync(character);

    public async ValueTask<CartoonCharacter> RemoveCartoonCharacterAsync(Guid characterId) =>
        await this._storageBroker.DeleteCartoonCharacterAsync(characterId);
}