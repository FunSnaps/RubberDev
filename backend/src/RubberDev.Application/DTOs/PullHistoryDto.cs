namespace RubberDev.Application.DTOs;

public record PullHistoryDto(
    Guid PullId,
    DateTimeOffset PulledAt,
    IReadOnlyList<CharacterDto> PulledCharacters
);