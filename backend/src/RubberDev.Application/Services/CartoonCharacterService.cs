using RubberDev.Application.Interfaces;
using RubberDev.Domain.Entities;

namespace RubberDev.Application.Services;

public class CartoonCharacterService : ICartoonCharacterService
{
    private readonly IStorageBroker _storageBroker;

    public CartoonCharacterService(IStorageBroker storageBroker)
    {
        _storageBroker = storageBroker;
    }

    public async Task<CartoonCharacter> AddCartoonCharacterAsync(
        CartoonCharacter character,
        CancellationToken cancellationToken = default)
    {
        if (character is null)
            throw new ArgumentNullException(nameof(character));

        if (string.IsNullOrWhiteSpace(character.Name))
            throw new ArgumentException("Name is required.", nameof(character.Name));

        if (character.Id == Guid.Empty)
            character.Id = Guid.NewGuid();

        return await _storageBroker
            .InsertCartoonCharacterAsync(character, cancellationToken);
    }

    public Task<IEnumerable<CartoonCharacter>> RetrieveAllCartoonCharactersAsync(
        CancellationToken cancellationToken = default)
    {
        return _storageBroker.SelectAllCartoonCharactersAsync(cancellationToken);
    }

    public async Task<CartoonCharacter> RetrieveCartoonCharacterByIdAsync(
        Guid characterId,
        CancellationToken cancellationToken = default)
    {
        var character = await _storageBroker
            .SelectCartoonCharacterByIdAsync(characterId, cancellationToken);

        return character
               ?? throw new KeyNotFoundException($"Character {characterId} not found.");
    }

    public async Task<CartoonCharacter> ModifyCartoonCharacterAsync(
        CartoonCharacter character,
        CancellationToken cancellationToken = default)
    {
        if (character is null)
            throw new ArgumentNullException(nameof(character));

        await RetrieveCartoonCharacterByIdAsync(character.Id, cancellationToken);

        return await _storageBroker
            .UpdateCartoonCharacterAsync(character, cancellationToken);
    }

    public async Task<bool> RemoveCartoonCharacterAsync(
        Guid characterId,
        CancellationToken cancellationToken = default)
    {
        return await _storageBroker
            .DeleteCartoonCharacterAsync(characterId, cancellationToken);
    }
}