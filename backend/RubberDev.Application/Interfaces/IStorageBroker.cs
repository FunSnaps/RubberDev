using RubberDev.Domain.Entities;

namespace RubberDev.Application.Interfaces;

public interface IStorageBroker
{
    ValueTask<CartoonCharacter> InsertCartoonCharacterAsync(CartoonCharacter character);
    IQueryable<CartoonCharacter> SelectAllCartoonCharacters();
    ValueTask<CartoonCharacter> SelectCartoonCharacterByIdAsync(Guid characterId);
    ValueTask<CartoonCharacter> UpdateCartoonCharacterAsync(CartoonCharacter character);
    ValueTask<CartoonCharacter> DeleteCartoonCharacterAsync(Guid characterId);
}