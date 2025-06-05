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
        if (count != 1 && count != 5)
            throw new ArgumentException(
                "Pull count must be 1 or 5.", nameof(count));

        // 1) load all characters
        var allCharacters = (await _storageBroker
                .SelectAllCartoonCharactersAsync(cancellationToken))
            .ToList();

        if (!allCharacters.Any())
            throw new InvalidOperationException(
                "No characters available for pulling.");

        // 2) partition by rarity
        var common = allCharacters.Where(c => c.Rarity <= 2).ToList();
        var rare = allCharacters.Where(c => c.Rarity == 3).ToList();
        var epic = allCharacters.Where(c => c.Rarity == 4).ToList();
        var legendary = allCharacters.Where(c => c.Rarity == 5).ToList();

        // 3) build a new batch
        var batch = new PullBatch
        {
            PullBatchId = Guid.NewGuid(),
            PulledAt = DateTimeOffset.UtcNow
        };

        var pulledDtos = new List<CharacterDto>();

        for (var i = 0; i < count; i++)
        {
            var roll = _random.NextDouble();
            CartoonCharacter selected;

            if (roll < PullOdds.Legendary && legendary.Any())
                selected = PickRandom(legendary);
            else if (roll < PullOdds.Legendary + PullOdds.Epic && epic.Any())
                selected = PickRandom(epic);
            else if (roll < PullOdds.Legendary + PullOdds.Epic + PullOdds.Rare && rare.Any())
                selected = PickRandom(rare);
            else
                selected = PickRandom(common);

            // 4) record the item
            batch.Items.Add(new PullItem
            {
                PullItemId = Guid.NewGuid(),
                PullBatchId = batch.PullBatchId,
                CharacterId = selected.Id
            });

            // 5) map to DTO
            pulledDtos.Add(new CharacterDto(
                selected.Id,
                selected.Name,
                selected.Origin,
                selected.Abilities,
                selected.Rarity,
                selected.ImageUrl));
        }

        // 6) persist entire batch
        await _storageBroker
            .InsertPullBatchAsync(batch, cancellationToken);

        return new PullBatchDto(
            batch.PullBatchId,
            batch.PulledAt,
            pulledDtos);
    }

    public async Task<IEnumerable<PullBatchDto>> RetrieveAllPullBatchesAsync(
        CancellationToken cancellationToken = default)
    {
        var batches = await _storageBroker
            .SelectAllPullBatchesAsync(cancellationToken);

        var result = new List<PullBatchDto>();

        // for each batch, load character details and project
        foreach (var batch in batches)
        {
            var characterIds = batch.Items
                .Select(i => i.CharacterId)
                .ToList();

            var characters = (await _storageBroker
                    .SelectAllCartoonCharactersAsync(cancellationToken))
                .Where(c => characterIds.Contains(c.Id))
                .Select(c => new CharacterDto(
                    c.Id, c.Name, c.Origin,
                    c.Abilities, c.Rarity, c.ImageUrl))
                .ToList();

            result.Add(new PullBatchDto(
                batch.PullBatchId,
                batch.PulledAt,
                characters));
        }

        return result;
    }

    public async Task<PullBatchDto?> RetrievePullBatchByIdAsync(
        Guid batchId,
        CancellationToken cancellationToken = default)
    {
        // 1) Fetch the batch (with its items)
        var batch = await _storageBroker
            .SelectPullBatchByIdAsync(batchId, cancellationToken);

        if (batch is null)
            return null;

        // 2) Load character details for each item
        var allChars = await _storageBroker
            .SelectAllCartoonCharactersAsync(cancellationToken);

        var characterMap = allChars.ToDictionary(c => c.Id);

        var pulledDtos = batch.Items
            .Select(item =>
            {
                var c = characterMap[item.CharacterId];
                return new CharacterDto(
                    c.Id, c.Name, c.Origin,
                    c.Abilities, c.Rarity, c.ImageUrl);
            })
            .ToList();

        // 3) Project into DTO
        return new PullBatchDto(
            batch.PullBatchId,
            batch.PulledAt,
            pulledDtos);
    }

    private static T PickRandom<T>(List<T> list)
    {
        return list[new Random().Next(list.Count)];
    }
}