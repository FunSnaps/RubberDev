using RubberDev.Application.DTOs;

namespace RubberDev.Application.UseCases;

/// <summary>
/// Orchestrates gacha pulls and retrieval of pull history.
/// </summary>
public interface IGachaService
{
    /// <summary>
    /// Perform a gacha pull of the specified count (1 or 5).
    /// </summary>
    Task<PullBatchDto> PullAsync(
        int count,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieve all past pull batches (with their pulled characters).
    /// </summary>
    Task<IEnumerable<PullBatchDto>> RetrieveAllPullBatchesAsync(
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieve one specific pull batch (and its pulled characters) by batch ID.
    /// </summary>
    Task<PullBatchDto?> RetrievePullBatchByIdAsync(
        Guid batchId,
        CancellationToken cancellationToken = default);
}