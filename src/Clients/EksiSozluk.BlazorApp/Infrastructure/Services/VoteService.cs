using EksiSozluk.BlazorApp.Infrastructure.Models.Enums;
using EksiSozluk.BlazorApp.Infrastructure.Services.Interfaces;

namespace EksiSozluk.BlazorApp.Infrastructure.Services;

public class VoteService : IVoteService
{
    private readonly HttpClient _client;

    public VoteService(HttpClient client)
    {
        _client = client;
    }

    public async Task DeleteEntryVote(Guid id)
    {
        var response = await _client.PostAsync($"/api/Vote/DeleteEntryVote/{id}", null);
        
    }
    public async Task DeleteEntryCommentVote(Guid id)
    {
        var response = await _client.PostAsync($"/api/Vote/DeleteEntryCommentVote/{id}", null);
        
    }
    public async Task CreateEntryUpVote(Guid id)
    {
        await CreateEntryVote(id, VoteType.UpVote);
    }
    public async Task CreateEntryDownVote(Guid id)
    {
        await CreateEntryVote(id, VoteType.DownVote);
    }
    public async Task CreateEntryCommentUpVote(Guid id)
    {
        await CreateEntryCommentVote(id, VoteType.UpVote);
    }
    public async Task CreateEntryCommentDownVote(Guid id)
    {
        await CreateEntryCommentVote(id, VoteType.DownVote);
    }
    private async Task<HttpResponseMessage> CreateEntryVote(Guid id, VoteType type)
    {
        return await _client.PostAsync($"/api/Vote/Entry/{id}?votetype={type}", null);
    }
    private async Task<HttpResponseMessage> CreateEntryCommentVote(Guid id, VoteType type)
    {
        return await _client.PostAsync($"/api/Vote/EntryComment/{id}?votetype={type}", null);
    }



}