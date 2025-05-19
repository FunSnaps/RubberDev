using RubberDev.Domain.Entities;

namespace RubberDev.Application.Interfaces;

public interface ICartoonCharacterService
{
    ValueTask<CartoonCharacter> AddCartoonCharacterAsync(CartoonCharacter character);
    IQueryable<CartoonCharacter> RetrieveAllCartoonCharacters();
    ValueTask<CartoonCharacter> RetrieveCartoonCharacterByIdAsync(Guid characterId);
    ValueTask<CartoonCharacter> ModifyCartoonCharacterAsync(CartoonCharacter character);
    ValueTask<CartoonCharacter> RemoveCartoonCharacterAsync(Guid characterId);
}