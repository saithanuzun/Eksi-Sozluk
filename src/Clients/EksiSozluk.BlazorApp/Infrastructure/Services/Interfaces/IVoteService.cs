namespace EksiSozluk.BlazorApp.Infrastructure.Services.Interfaces;

public interface IVoteService
{
    Task DeleteEntryVote(Guid id);
    Task DeleteEntryCommentVote(Guid id);
    Task CreateEntryUpVote(Guid id);
    Task CreateEntryDownVote(Guid id);
    Task CreateEntryCommentUpVote(Guid id);
    Task CreateEntryCommentDownVote(Guid id);
}