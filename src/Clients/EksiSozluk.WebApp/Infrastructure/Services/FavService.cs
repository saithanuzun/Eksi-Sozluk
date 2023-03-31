using EksiSozluk.WebApp.Infrastructure.Services.Interfaces;

namespace EksiSozluk.WebApp.Infrastructure.Services;

public class FavService : IFavService
{
    private readonly HttpClient _client;

    public FavService(HttpClient client)
    {
        _client = client;
    }
    public async Task CreateEntryFav(Guid entryId)
    {
        await _client.PostAsync($"/api/Favourite/Entry/{entryId}", null);
    }

    public async Task CreateEntryCommentFav(Guid entryCommentId)
    {
        await _client.PostAsync($"/api/Favourite/EntryComment/{entryCommentId}", null);
    }

    public async Task DeleteEntryFav(Guid entryId)
    {
        await _client.PostAsync($"/api/Favourite/DeleteEntryFav/{entryId}", null);
    }

    public async Task DeleteEntryCommentFav(Guid entryCommentId)
    {
        await _client.PostAsync($"/api/Favourite/DeleteEntryCommentFav/{entryCommentId}", null);
    }
}