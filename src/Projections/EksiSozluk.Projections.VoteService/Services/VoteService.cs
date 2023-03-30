using System.Data.SqlClient;
using Dapper;

namespace EksiSozluk.Projections.VoteService.Services;

public class VoteService
{
    private readonly string connectionString;

    public VoteService(string connectionString)
    {
        this.connectionString = connectionString;
    }
    
    public async Task CreateEntryVote(CreateEntryVoteEvent vote)
    {
        await DeleteEntryVote(vote.EntryId, vote.UserId);

        using var connection = new SqlConnection(connectionString);

        await connection.ExecuteAsync("INSERT INTO ENTRYVOTE (Id, CreatedDate, EntryId, VoteType, CreatedById) VALUES (@Id, GETDATE(), @EntryId, @VoteType, @CreatedById)",
            new
            {
                Id = Guid.NewGuid(),
                EntryId = vote.EntryId,
                VoteType = (int)vote.VoteType,
                CreatedById = vote.UserId
            });
    }

    public async Task DeleteEntryVote(Guid entryId, Guid userId)
    {
        using var connection = new SqlConnection(connectionString);

        await connection.ExecuteAsync("DELETE FROM EntryVote WHERE EntryId = @EntryId AND CREATEDBYID = @UserId",
            new
            {
                EntryId = entryId,
                UserId = userId
            });
    }

    public async Task CreateEntryCommentVote(CreateEntryCommentVoteEvent vote)
    {
        await DeleteEntryCommentVote(vote.EntryCommentId, vote.CreatedBy);

        using var connection = new SqlConnection(connectionString);

        await connection.ExecuteAsync("INSERT INTO entrycommentvote (Id, CreatedDate, EntryCommentId, VoteType, CREATEDBYID) VALUES (@Id, GETDATE(), @EntryCommentId, @VoteType, @CreatedById)",
            new
            {
                Id = Guid.NewGuid(),
                EntryCommentId = vote.EntryCommentId,
                VoteType = Convert.ToInt16(vote.VoteType),
                CreatedById = vote.CreatedBy
            });
    }

    public async Task DeleteEntryCommentVote(Guid entryCommentId, Guid userId)
    {
        using var connection = new SqlConnection(connectionString);

        await connection.ExecuteAsync("DELETE FROM entrycommentvote WHERE EntryCommentId = @EntryCommentId AND CREATEDBYID = @UserId",
            new
            {
                EntryCommentId = entryCommentId,
                UserId = userId
            });
    }
}