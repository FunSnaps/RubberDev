namespace RubberDev.Application.DTOs;

public record PullBatchDto(
    Guid PullBatchId,
    DateTimeOffset PulledAt,
    IReadOnlyList<CharacterDto> PulledCharacters
);