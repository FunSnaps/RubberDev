using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using RubberDev.Application.UseCases;
using RubberDev.Domain.Entities;

namespace RubberDev.Infrastructure.Brokers;

public class StorageBroker : IStorageBroker
{
    private readonly string _connectionString;

    public StorageBroker(IConfiguration configuration)
    {
        _connectionString = configuration
                                .GetConnectionString("DefaultConnection")
                            ?? throw new InvalidOperationException("Missing DefaultConnection");
    }

    private IDbConnection CreateDbConnection()
    {
        return new SqlConnection(_connectionString);
    }

    // ── CartoonCharacter CRUD ───────────────────────────────────────

    public async Task<CartoonCharacter> InsertCartoonCharacterAsync(
        CartoonCharacter character,
        CancellationToken cancellationToken = default)
    {
        const string sql = @"
                INSERT INTO CartoonCharacters
                  (Id, Name, Origin, Abilities, Rarity, ImageUrl)
                VALUES
                  (@Id, @Name, @Origin, @Abilities, @Rarity, @ImageUrl);";

        using var db = CreateDbConnection();
        await db.ExecuteAsync(new CommandDefinition(
            sql,
            character,
            cancellationToken: cancellationToken));

        return character;
    }

    public async Task<IEnumerable<CartoonCharacter>> SelectAllCartoonCharactersAsync(
        CancellationToken cancellationToken = default)
    {
        const string sql = "SELECT * FROM CartoonCharacters;";

        using var db = CreateDbConnection();
        return await db.QueryAsync<CartoonCharacter>(new CommandDefinition(
            sql,
            cancellationToken: cancellationToken));
    }

    public async Task<CartoonCharacter?> SelectCartoonCharacterByIdAsync(
        Guid characterId,
        CancellationToken cancellationToken = default)
    {
        const string sql = "SELECT * FROM CartoonCharacters WHERE Id = @Id;";

        using var db = CreateDbConnection();
        return await db.QueryFirstOrDefaultAsync<CartoonCharacter>(new CommandDefinition(
            sql,
            new { Id = characterId },
            cancellationToken: cancellationToken));
    }

    public async Task<CartoonCharacter> UpdateCartoonCharacterAsync(
        CartoonCharacter character,
        CancellationToken cancellationToken = default)
    {
        const string sql = @"
                UPDATE CartoonCharacters
                   SET Name      = @Name,
                       Origin    = @Origin,
                       Abilities = @Abilities,
                       Rarity    = @Rarity,
                       ImageUrl  = @ImageUrl
                 WHERE Id = @Id;";

        using var db = CreateDbConnection();
        await db.ExecuteAsync(new CommandDefinition(
            sql,
            character,
            cancellationToken: cancellationToken));

        return character;
    }

    public async Task<bool> DeleteCartoonCharacterAsync(
        Guid characterId,
        CancellationToken cancellationToken = default)
    {
        const string sql = "DELETE FROM CartoonCharacters WHERE Id = @Id;";

        using var db = CreateDbConnection();
        var affected = await db.ExecuteAsync(new CommandDefinition(
            sql,
            new { Id = characterId },
            cancellationToken: cancellationToken));

        return affected > 0;
    }

    // ── Gacha Pull Batch (Batch + Items) ────────────────────────────

    public async Task InsertPullBatchAsync(
        PullBatch batch,
        CancellationToken cancellationToken = default)
    {
        using var db = CreateDbConnection();

        // 1) Insert the batch record
        await db.ExecuteAsync(new CommandDefinition(
            InsertBatchSql,
            batch,
            cancellationToken: cancellationToken));

        // 2) Insert each pull item
        foreach (var item in batch.Items)
            await db.ExecuteAsync(new CommandDefinition(
                InsertItemSql,
                item,
                cancellationToken: cancellationToken));
    }

    public async Task<IEnumerable<PullBatch>> SelectAllPullBatchesAsync(
        CancellationToken cancellationToken = default)
    {
        const string sql = @"
                SELECT
                  b.PullBatchId, b.PulledAt,
                  i.PullItemId, i.CharacterId
                FROM PullBatches b
                JOIN PullItems i
                  ON b.PullBatchId = i.PullBatchId
                ORDER BY b.PulledAt DESC;";

        using var db = CreateDbConnection();
        var lookup = new Dictionary<Guid, PullBatch>();

        await db.QueryAsync<PullBatch, PullItem, PullBatch>(new CommandDefinition(
                sql,
                cancellationToken: cancellationToken),
            (batch, item) =>
            {
                if (!lookup.TryGetValue(batch.PullBatchId, out var existing))
                {
                    existing = batch;
                    existing.Items = new List<PullItem>();
                    lookup.Add(batch.PullBatchId, existing);
                }

                lookup[batch.PullBatchId].Items.Add(item);
                return existing;
            },
            "PullItemId");

        return lookup.Values;
    }

    public async Task<PullBatch?> SelectPullBatchByIdAsync(
        Guid pullBatchId,
        CancellationToken cancellationToken = default)
    {
        const string sql = @"
                SELECT
                  b.PullBatchId, b.PulledAt,
                  i.PullItemId, i.CharacterId
                FROM PullBatches b
                JOIN PullItems i
                  ON b.PullBatchId = i.PullBatchId
                WHERE b.PullBatchId = @PullBatchId;";

        using var db = CreateDbConnection();
        var lookup = new Dictionary<Guid, PullBatch>();

        await db.QueryAsync<PullBatch, PullItem, PullBatch>(new CommandDefinition(
                sql,
                new { PullBatchId = pullBatchId },
                cancellationToken: cancellationToken),
            (batch, item) =>
            {
                if (!lookup.TryGetValue(batch.PullBatchId, out var existing))
                {
                    existing = batch;
                    existing.Items = new List<PullItem>();
                    lookup.Add(batch.PullBatchId, existing);
                }

                lookup[batch.PullBatchId].Items.Add(item);
                return existing;
            },
            "PullItemId");

        return lookup.Values.SingleOrDefault();
    }

    private const string InsertBatchSql = @"
            INSERT INTO PullBatches
              (PullBatchId, PulledAt)
            VALUES
              (@PullBatchId, @PulledAt);";

    private const string InsertItemSql = @"
            INSERT INTO PullItems
              (PullItemId, PullBatchId, CharacterId)
            VALUES
              (@PullItemId, @PullBatchId, @CharacterId);";
}