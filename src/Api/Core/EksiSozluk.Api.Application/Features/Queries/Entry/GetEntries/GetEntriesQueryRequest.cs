using MediatR;

namespace EksiSozluk.Api.Application.Features.Queries.Entry.GetEntries;

public class GetEntriesQueryRequest : IRequest<List<GetEntriesQueryResponse>>
{
    public bool TodaysEntries { get; set; }
    public int Count { get; set; } = 20;
}