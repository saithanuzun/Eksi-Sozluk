using Dapper;
using Npgsql;

namespace EksiSozluk.Projections.VoteService.Services;

public class VoteService
{
    private readonly string connectionString =         
            "USER ID=postgres ; Password=password123;Server=localhost;Port=5432;Database=eksisozluk;Integrated Security=true;Pooling=true";
    
    public async Task CreateEntryVote(CreateEntryVoteEvent vote)
    {
        await DeleteEntryVote(vote.EntryId, vote.UserId);

        using var connection = new NpgsqlConnection(connectionString);
        connection.Open();

        await connection.ExecuteAsync(
            "INSERT INTO dbo.entryvote (\"Id\", \"CreatedDate\", \"EntryId\", \"VoteType\", \"CreatedById\") VALUES (@Id, current_date , @EntryId, @VoteType, @CreatedById)",
            new
            {
                Id = Guid.NewGuid(),
                vote.EntryId,
                VoteType = (int)vote.VoteType,
                CreatedById = vote.UserId
            });
    }

    public async Task DeleteEntryVote(Guid entryId, Guid userId)
    {
        using var connection = new NpgsqlConnection(connectionString);
        connection.Open();

        await connection.ExecuteAsync("DELETE FROM dbo.entryvote WHERE \"EntryId\" = @EntryId AND \"CreatedById\" = @UserId",
            new
            {
                EntryId = entryId,
                UserId = userId
            });
    }
    

    public async Task CreateEntryCommentVote(CreateEntryCommentVoteEvent vote)
    {
        
        await DeleteEntryCommentVote(vote.EntryCommentId, vote.CreatedBy);

        using var connection = new NpgsqlConnection(connectionString);
        connection.Open();


        await connection.ExecuteAsync(
            "INSERT INTO dbo.entrycommentvote (\"Id\", \"CreatedDate\", \"EntryCommentId\", \"VoteType\", \"CreatedById\") VALUES (@Id, current_date, @EntryCommentId, @VoteType, @CreatedById)",
            new
            {
                Id = Guid.NewGuid(),
                vote.EntryCommentId,
                VoteType = Convert.ToInt16(vote.VoteType),
                CreatedById = vote.CreatedBy
            });
    }

    public async Task DeleteEntryCommentVote(Guid entryCommentId, Guid userId)
    {
        using var connection = new NpgsqlConnection(connectionString);
        connection.Open();

        await connection.ExecuteAsync(
            "DELETE FROM dbo.entrycommentvote WHERE \"EntryCommentId\" = @EntryCommentId AND \"CreatedById\" = @UserId",
            new
            {
                EntryCommentId = entryCommentId,
                UserId = userId
            });
    }
}