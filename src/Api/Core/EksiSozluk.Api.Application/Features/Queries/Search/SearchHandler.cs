using EksiSozluk.Api.Application.Interfaces.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EksiSozluk.Api.Application.Features.Queries.Search;

public class SearchHandler : IRequestHandler<SearchRequest,List<SearchResponse>>
{
    private IEntryRepository _entryRepository;


    public SearchHandler(IEntryRepository entryRepository)
    {
        _entryRepository = entryRepository;
    }

    public async Task<List<SearchResponse>> Handle(SearchRequest request, CancellationToken cancellationToken)
    {
        // validation check search text min 3 value
        var result = _entryRepository
            .Get(i => EF.Functions.Like(i.Subject, $"{request.SearchText}%"))
            .Select(i => new SearchResponse()
            {
                Id = i.Id,
                Subject = i.Subject,
            });
        return await result.ToListAsync(cancellationToken: cancellationToken);
    }
}