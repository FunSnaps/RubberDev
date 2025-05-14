using System.Data;
using Dapper;
using RubberDev.Models;
using RubberDev.Brokers;
using Microsoft.Extensions.Configuration;

namespace RubberDev.Infrastructure;

public class StorageBroker : IStorageBroker
{
    private readonly IConfiguration configuration;
    private readonly string connectionString;

    public StorageBroker(IConfiguration configuration)
    {
        this.configuration = configuration;
        this.connectionString = configuration.GetConnectionString("DefaultConnection");
    }

    public async ValueTask<CartoonCharacter> InsertCartoonCharacterAsync(CartoonCharacter character)
    {
        using IDbConnection db = new MySql.Data.MySqlClient.MySqlConnection(connectionString);

        string sql = @"
            INSERT INTO CartoonCharacters 
            (Id, Name, Origin, Abilities, Rarity, ImageUrl)
            VALUES 
            (@Id, @Name, @Origin, @Abilities, @Rarity, @ImageUrl)";

        await db.ExecuteAsync(sql, character);
        return character;
    }

    public IQueryable<CartoonCharacter> SelectAllCartoonCharacters()
    {
        using IDbConnection db = new MySql.Data.MySqlClient.MySqlConnection(connectionString);
        string sql = "SELECT * FROM CartoonCharacters";
        return db.Query<CartoonCharacter>(sql).AsQueryable();
    }

    public async ValueTask<CartoonCharacter> SelectCartoonCharacterByIdAsync(Guid characterId)
    {
        using IDbConnection db = new MySql.Data.MySqlClient.MySqlConnection(connectionString);
        string sql = "SELECT * FROM CartoonCharacters WHERE Id = @Id";
        return await db.QueryFirstOrDefaultAsync<CartoonCharacter>(sql, new { Id = characterId });
    }

    public async ValueTask<CartoonCharacter> UpdateCartoonCharacterAsync(CartoonCharacter character)
    {
        using IDbConnection db = new MySql.Data.MySqlClient.MySqlConnection(connectionString);

        string sql = @"
            UPDATE CartoonCharacters SET
            Name = @Name,
            Origin = @Origin,
            Abilities = @Abilities,
            Rarity = @Rarity,
            ImageUrl = @ImageUrl
            WHERE Id = @Id";

        await db.ExecuteAsync(sql, character);
        return character;
    }

    public async ValueTask<CartoonCharacter> DeleteCartoonCharacterAsync(Guid characterId)
    {
        using IDbConnection db = new MySql.Data.MySqlClient.MySqlConnection(connectionString);
        string sql = "DELETE FROM CartoonCharacters WHERE Id = @Id";
        await db.ExecuteAsync(sql, new { Id = characterId });

        // Optional: return null or stub-deleted character
        return null!;
    }
}
