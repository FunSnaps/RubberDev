namespace RubberDev.Application.DTOs;

public record GachaResultDto(
    IReadOnlyList<CharacterDto> PulledCharacters
);