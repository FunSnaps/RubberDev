using RubberDev.Application.DTOs;

namespace RubberDev.Application.Interfaces;

public interface IGachaService
{
    /// <summary>
    /// Perform a gacha pull of the given count (1 or 3).
    /// </summary>
    Task<GachaResultDto> PullAsync(
        int count,
        CancellationToken cancellationToken = default);
}