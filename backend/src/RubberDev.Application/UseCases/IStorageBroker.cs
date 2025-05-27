using RubberDev.Domain.Entities;

namespace RubberDev.Application.Interfaces;

public interface IStorageBroker
{
    Task<CartoonCharacter> InsertCartoonCharacterAsync(
        CartoonCharacter character,
        CancellationToken cancellationToken = default);

    Task<IEnumerable<CartoonCharacter>> SelectAllCartoonCharactersAsync(
        CancellationToken cancellationToken = default);

    Task<CartoonCharacter?> SelectCartoonCharacterByIdAsync(
        Guid characterId,
        CancellationToken cancellationToken = default);

    Task<CartoonCharacter> UpdateCartoonCharacterAsync(
        CartoonCharacter character,
        CancellationToken cancellationToken = default);

    Task<bool> DeleteCartoonCharacterAsync(
        Guid characterId,
        CancellationToken cancellationToken = default);
    
    Task InsertPullAsync(
        Pull pull,
        CancellationToken cancellationToken = default);
}