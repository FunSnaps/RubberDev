using RubberDev.Application.DTOs;
using RubberDev.Application.Interfaces;
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

    public async Task<GachaResultDto> PullAsync(
        int count,
        CancellationToken cancellationToken = default)
    {
        if (count != 1 && count != 3)
            throw new ArgumentException("Pull count must be 1 or 3.", nameof(count));

        // 1) Fetch all characters
        var allChars = await _storageBroker
            .SelectAllCartoonCharactersAsync(cancellationToken);

        // 2) Partition by rarity
        var cartoonCharacters = allChars.ToList();
        
        if (!cartoonCharacters.Any())
            throw new InvalidOperationException("No characters available for pulling.");
        
        var common = cartoonCharacters.Where(c => c.Rarity <= 2).ToList();
        var rare = cartoonCharacters.Where(c => c.Rarity == 3).ToList();
        var epic = cartoonCharacters.Where(c => c.Rarity == 4).ToList();
        var legendary = cartoonCharacters.Where(c => c.Rarity == 5).ToList();

        var pulled = new List<CharacterDto>();

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

            // 3) Persist the pull
            var pullRecord = new Pull(selected.Id);
            await _storageBroker.InsertPullAsync(pullRecord, cancellationToken);

            // 4) Map to DTO
            pulled.Add(new CharacterDto(
                selected.Id,
                selected.Name,
                selected.Origin,
                selected.Abilities,
                selected.Rarity,
                selected.ImageUrl));
        }

        return new GachaResultDto(pulled);
    }

    private static T PickRandom<T>(List<T> list)
    {
        var idx = new Random().Next(list.Count);
        return list[idx];
    }
}