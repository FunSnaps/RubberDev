using RubberDev.Domain.Entities;

namespace RubberDev.Application.UseCases;

public interface ICartoonCharacterService
{
    Task<CartoonCharacter> AddCartoonCharacterAsync(
        CartoonCharacter character,
        CancellationToken cancellationToken = default);

    Task<IEnumerable<CartoonCharacter>> RetrieveAllCartoonCharactersAsync(
        CancellationToken cancellationToken = default);

    Task<CartoonCharacter> RetrieveCartoonCharacterByIdAsync(
        Guid characterId,
        CancellationToken cancellationToken = default);

    Task<CartoonCharacter> ModifyCartoonCharacterAsync(
        CartoonCharacter character,
        CancellationToken cancellationToken = default);

    Task<bool> RemoveCartoonCharacterAsync(
        Guid characterId,
        CancellationToken cancellationToken = default);
}