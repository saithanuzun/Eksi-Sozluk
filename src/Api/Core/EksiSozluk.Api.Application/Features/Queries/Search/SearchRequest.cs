using MediatR;

namespace EksiSozluk.Api.Application.Features.Queries.Search;

public class SearchRequest : IRequest<List<SearchResponse>>
{
    public string SearchText { get; set; }
}