namespace RubberDev.Application.DTOs;

public record GachaResultDto(
    Guid PullBatchId,
    DateTimeOffset PulledAt,
    IReadOnlyList<CharacterDto> PulledCharacters
);