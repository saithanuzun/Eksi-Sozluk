using EksiSozluk.WebApp.Infrastructure.Models.DTO;
using EksiSozluk.WebApp.Infrastructure.Models.DVO;
using EksiSozluk.WebApp.Infrastructure.Models.Pagination;

namespace EksiSozluk.WebApp.Infrastructure.Services.Interfaces;

public interface IEntryService
{
    Task<List<EntriesDvo>> GetEntires();
    Task<EntryDetailsDvo> GetEntryDetail(Guid entryId);
    Task<PagedViewModel<EntryDetailsDvo>> GetMainPageEntries(int page, int pageSize);
    Task<PagedViewModel<EntryDetailsDvo>> GetProfilePageEntries(int page, int pageSize, string userName = null);
    Task<PagedViewModel<EntryCommentsDvo>> GetEntryComments(Guid entryId, int page, int pageSize);
    Task<Guid> CreateEntry(CreateEntryDto command);
    Task<Guid> CreateEntryComment(CreateEntryCommentDto command);
    Task<List<SearchEntryDvo>> SearchBySubject(string searchText);
}