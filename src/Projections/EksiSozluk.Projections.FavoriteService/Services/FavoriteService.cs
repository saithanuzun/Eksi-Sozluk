using Dapper;
using EksiSozluk.Projections.FavoriteService.RabbitMQ.Events;
using Npgsql;

namespace EksiSozluk.Projections.FavoriteService.Services;

public class FavoriteService
{
    private readonly string connectionString =
        "USER ID=postgres ; Password=password123;Server=localhost;Port=5432;Database=eksisozluk;Integrated Security=true;Pooling=true";

    public async Task CreateEntryFav(CreateEntryFavEvent @event)
    {
        using var connection = new NpgsqlConnection(connectionString);
        connection.Open();
        await connection
            .ExecuteAsync("INSERT INTO dbo.entryfavorite (\"Id\", \"EntryId\",\"CreatedById\", \"CreatedDate\") VALUES(@Id, @EntryId, @CreatedById, current_date)",
                new
                {
                    Id = Guid.NewGuid(),
                    EntryId = @event.EntryId,
                    CreatedById = @event.UserId
                });
    }

    public async Task CreateEntryCommentFav(CreateEntryCommentFavEvent @event)
    {
        using var connection = new NpgsqlConnection(connectionString);
        connection.Open();
        await connection.ExecuteAsync("INSERT INTO dbo.entrycommentfavorite (\"Id\", \"EntryCommentId\", \"CreatedById\", \"CreatedDate\") VALUES(@Id, @EntryCommentId, @CreatedById, current_date)",
            new
            {
                Id = Guid.NewGuid(),
                EntryCommentId = @event.EntryCommentId,
                CreatedById = @event.UserId
            });
    }

    public async Task DeleteEntryFav(DeleteEntryFavEvent @event)
    {
        using var connection = new NpgsqlConnection(connectionString);
        connection.Open();
        
        await connection.ExecuteAsync("DELETE FROM dbo.entryfavorite WHERE \"EntryId\" = @EntryId AND \"CreatedById\" = @CreatedById",
            new
            {
                Id = Guid.NewGuid(),
                EntryId = @event.EntryId,
                CreatedById = @event.UserId
            });
    }

    public async Task DeleteEntryCommentFav(DeleteEntryCommentFavEvent @event)
    {
        using var connection = new NpgsqlConnection(connectionString);
        connection.Open();
        await connection.ExecuteAsync("DELETE FROM dbo.entrycommentfavorite WHERE \"EntryCommentId\" = @EntryCommentId AND \"CreatedById\" = @CreatedById",
            new
            {
                Id = Guid.NewGuid(),
                EntryCommentId = @event.EntryCommentId,
                CreatedById = @event.UserId
            });
    }
}