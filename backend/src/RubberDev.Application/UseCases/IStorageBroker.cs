using RubberDev.Domain.Entities;

namespace RubberDev.Application.UseCases;

/// <summary>
/// Defines persistence operations for cartoon characters and gacha pull batches.
/// </summary>
public interface IStorageBroker
{
    // ── CartoonCharacter CRUD ─────────────────────────────────────────

    Task<CartoonCharacter> InsertCartoonCharacterAsync(
        CartoonCharacter character,
        CancellationToken cancellationToken = default);

    Task<IEnumerable<CartoonCharacter>> SelectAllCartoonCharactersAsync(
        CancellationToken cancellationToken = default);

    Task<CartoonCharacter?> SelectCartoonCharacterByIdAsync(
        Guid characterId,
        CancellationToken cancellationToken = default);

    Task<CartoonCharacter> UpdateCartoonCharacterAsync(
        CartoonCharacter character,
        CancellationToken cancellationToken = default);

    Task<bool> DeleteCartoonCharacterAsync(
        Guid characterId,
        CancellationToken cancellationToken = default);

    // ── Gacha Pull Batch ──────────────────────────────────────────────

    /// <summary>
    /// Persists a batch header and its items (one per character).
    /// </summary>
    Task InsertPullBatchAsync(
        PullBatch batch,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves all gacha pull batches, including their items.
    /// </summary>
    Task<IEnumerable<PullBatch>> SelectAllPullBatchesAsync(
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves one pull batch (and its items) by batch ID.
    /// </summary>
    Task<PullBatch?> SelectPullBatchByIdAsync(
        Guid pullBatchId,
        CancellationToken cancellationToken = default);
}