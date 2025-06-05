using RubberDev.Application.DTOs;
using RubberDev.Application.UseCases;
using RubberDev.Domain.Entities;
using RubberDev.Domain.ValueObjects;

namespace RubberDev.Application.Services;

public class GachaService : IGachaService
{
    private readonly IStorageBroker _storageBroker;
    private readonly Random _random;

    public GachaService(IStorageBroker storageBroker)
    {
        _storageBroker = storageBroker;
        _random = new Random();
    }

    public async Task<PullBatchDto> PullAsync(
        int count,
        CancellationToken cancellationToken = default)
    {
        ValidatePullCount(count);

        var allCharacters = (await _storageBroker
                .SelectAllCartoonCharactersAsync(cancellationToken))
            .ToList();

        if (!allCharacters.Any())
            throw new InvalidOperationException("No characters available for pulling.");

        var grouped = GroupByRarity(allCharacters);

        var batch = new PullBatch
        {
            PullBatchId = Guid.NewGuid(),
            PulledAt = DateTimeOffset.UtcNow
        };

        var pulledDtos = new List<CharacterDto>();

        for (int i = 0; i < count; i++)
        {
            var selected = GetCharacterByOdds(grouped);
            batch.Items.Add(new PullItem
            {
                PullItemId = Guid.NewGuid(),
                PullBatchId = batch.PullBatchId,
                CharacterId = selected.Id
            });

            pulledDtos.Add(MapToDto(selected));
        }

        await _storageBroker.InsertPullBatchAsync(batch, cancellationToken);

        return new PullBatchDto(batch.PullBatchId, batch.PulledAt, pulledDtos);
    }

    public async Task<IEnumerable<PullBatchDto>> RetrieveAllPullBatchesAsync(
        CancellationToken cancellationToken = default)
    {
        var batches = await _storageBroker.SelectAllPullBatchesAsync(cancellationToken);
        var characters = await _storageBroker.SelectAllCartoonCharactersAsync(cancellationToken);
        var characterMap = characters.ToDictionary(c => c.Id);

        return batches.Select(batch =>
        {
            var dtos = batch.Items
                .Where(i => characterMap.ContainsKey(i.CharacterId))
                .Select(i => MapToDto(characterMap[i.CharacterId]))
                .ToList();

            return new PullBatchDto(batch.PullBatchId, batch.PulledAt, dtos);
        });
    }

    public async Task<PullBatchDto?> RetrievePullBatchByIdAsync(
        Guid batchId,
        CancellationToken cancellationToken = default)
    {
        var batch = await _storageBroker.SelectPullBatchByIdAsync(batchId, cancellationToken);
        if (batch is null) return null;

        var characters = await _storageBroker.SelectAllCartoonCharactersAsync(cancellationToken);
        var characterMap = characters.ToDictionary(c => c.Id);

        var pulledDtos = batch.Items
            .Where(i => characterMap.ContainsKey(i.CharacterId))
            .Select(i => MapToDto(characterMap[i.CharacterId]))
            .ToList();

        return new PullBatchDto(batch.PullBatchId, batch.PulledAt, pulledDtos);
    }

    // --- Private helpers ---

    private void ValidatePullCount(int count)
    {
        if (count != 1 && count != 5)
            throw new ArgumentException("Pull count must be 1 or 5.", nameof(count));
    }

    private static Dictionary<string, List<CartoonCharacter>> GroupByRarity(List<CartoonCharacter> all)
    {
        return new Dictionary<string, List<CartoonCharacter>>
        {
            ["Legendary"] = all.Where(c => c.Rarity == 5).ToList(),
            ["Epic"] = all.Where(c => c.Rarity == 4).ToList(),
            ["Rare"] = all.Where(c => c.Rarity == 3).ToList(),
            ["Common"] = all.Where(c => c.Rarity <= 2).ToList()
        };
    }

    private CartoonCharacter GetCharacterByOdds(Dictionary<string, List<CartoonCharacter>> grouped)
    {
        double roll = _random.NextDouble();

        if (roll < PullOdds.Legendary && grouped["Legendary"].Any())
            return PickRandom(grouped["Legendary"]);
        if (roll < PullOdds.Legendary + PullOdds.Epic && grouped["Epic"].Any())
            return PickRandom(grouped["Epic"]);
        if (roll < PullOdds.Legendary + PullOdds.Epic + PullOdds.Rare && grouped["Rare"].Any())
            return PickRandom(grouped["Rare"]);

        return PickRandom(grouped["Common"]);
    }

    private CartoonCharacter PickRandom(List<CartoonCharacter> list)
        => list[_random.Next(list.Count)];

    private CharacterDto MapToDto(CartoonCharacter c)
        => new(c.Id, c.Name, c.Origin, c.Abilities, c.Rarity, c.ImageUrl);
}
