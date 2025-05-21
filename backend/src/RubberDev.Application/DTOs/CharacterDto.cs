namespace RubberDev.Application.DTOs;

public record CharacterDto(
    Guid Id,
    string Name,
    string Origin,
    string Abilities,
    int Rarity,
    string ImageUrl
);