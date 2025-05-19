using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using RubberDev.Application.Interfaces;
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
        await db.ExecuteAsync(
                new CommandDefinition(
                    sql,
                    character,
                    cancellationToken: cancellationToken))
            .ConfigureAwait(false);

        return character;
    }

    public async Task<IEnumerable<CartoonCharacter>> SelectAllCartoonCharactersAsync(
        CancellationToken cancellationToken = default)
    {
        const string sql = "SELECT * FROM CartoonCharacters;";

        using var db = CreateDbConnection();
        return await db.QueryAsync<CartoonCharacter>(
                new CommandDefinition(
                    sql,
                    cancellationToken: cancellationToken))
            .ConfigureAwait(false);
    }

    public async Task<CartoonCharacter?> SelectCartoonCharacterByIdAsync(
        Guid characterId,
        CancellationToken cancellationToken = default)
    {
        const string sql = "SELECT * FROM CartoonCharacters WHERE Id = @Id;";

        using var db = CreateDbConnection();
        return await db.QueryFirstOrDefaultAsync<CartoonCharacter>(
                new CommandDefinition(
                    sql,
                    new { Id = characterId },
                    cancellationToken: cancellationToken))
            .ConfigureAwait(false);
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
        await db.ExecuteAsync(
                new CommandDefinition(
                    sql,
                    character,
                    cancellationToken: cancellationToken))
            .ConfigureAwait(false);

        return character;
    }

    public async Task<bool> DeleteCartoonCharacterAsync(
        Guid characterId,
        CancellationToken cancellationToken = default)
    {
        const string sql = "DELETE FROM CartoonCharacters WHERE Id = @Id;";

        using var db = CreateDbConnection();
        var affected = await db.ExecuteAsync(
                new CommandDefinition(
                    sql,
                    new { Id = characterId },
                    cancellationToken: cancellationToken))
            .ConfigureAwait(false);

        return affected > 0;
    }

    private IDbConnection CreateDbConnection()
    {
        return new SqlConnection(_connectionString);
    }
}