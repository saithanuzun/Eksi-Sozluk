using System.Net.Http.Json;
using EksiSozluk.BlazorApp.Infrastructure.Models.DTO;
using EksiSozluk.BlazorApp.Infrastructure.Models.DVO;
using EksiSozluk.BlazorApp.Infrastructure.Models.Pagination;
using EksiSozluk.BlazorApp.Infrastructure.Services.Interfaces;

namespace EksiSozluk.WebApp.Infrastructure.Services;

public class EntryService : IEntryService
{
    private readonly HttpClient _client;

    public EntryService(HttpClient client)
    {
        _client = client;
    }
    
    public async Task<List<EntriesDvo>> GetEntires()
    {
        var result = await _client.GetFromJsonAsync<List<EntriesDvo>>("/api/Entry?TodaysEntries=false&Count=30");
        

        return result;
    }

    public async Task<EntryDetailsDvo> GetEntryDetail(Guid entryId)
    {
        var result = await _client.GetFromJsonAsync<EntryDetailsDvo>($"/api/entry/{entryId}");

        return result;
    }

    public async Task<PagedViewModel<EntryDetailsDvo>> GetMainPageEntries(int page, int pageSize)
    {
        var result = await _client.GetFromJsonAsync<PagedViewModel<EntryDetailsDvo>>($"/api/entry/mainpageentries?page={page}&pageSize={pageSize}");

        return result;
    }

    public async Task<PagedViewModel<EntryDetailsDvo>> GetProfilePageEntries(int page, int pageSize, string userName = null)
    {
        var result = await _client.GetFromJsonAsync<PagedViewModel<EntryDetailsDvo>>($"/api/entry/UserEntries?userName={userName}&page={page}&pageSize={pageSize}");

        return result;
    }

    public async Task<PagedViewModel<EntryCommentsDvo>> GetEntryComments(Guid entryId, int page, int pageSize)
    {
        var result = await _client.GetFromJsonAsync<PagedViewModel<EntryCommentsDvo>>($"/api/entry/comments/{entryId}?page={page}&pageSize={pageSize}");

        return result;
    }


    public async Task<Guid> CreateEntry(CreateEntryDto command)
    {
        var response = await _client.PostAsJsonAsync("/api/Entry/CreateEntry", command);

        if (!response.IsSuccessStatusCode)
            return Guid.Empty;

        var guidStr = await response.Content.ReadAsStringAsync();

        return new Guid(guidStr.Trim('"'));
    }

    public async Task<Guid> CreateEntryComment(CreateEntryCommentDto command)
    {
        var response = await _client.PostAsJsonAsync("/api/Entry/CreateEntryComment", command);

        if (!response.IsSuccessStatusCode)
            return Guid.Empty;

        var guidStr = await response.Content.ReadAsStringAsync();

        return new Guid(guidStr.Trim('"'));
    }

    public async Task<List<SearchEntryDvo>> SearchBySubject(string searchText)
    {
        var result = await _client.GetFromJsonAsync<List<SearchEntryDvo>>($"/api/entry/Search?searchText={searchText}");

        return result;
    }
}