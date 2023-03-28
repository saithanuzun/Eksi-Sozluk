using EksiSozluk.Api.Application.Pagination;
using MediatR;

namespace EksiSozluk.Api.Application.Features.Queries.Entry.GetMainPageEntries;

public class GetMainPageEntriesQueryRequest : BasePagedQuery ,IRequest<PagedViewModel<GetMainPageEntriesQueryResponse>>
{
    public GetMainPageEntriesQueryRequest(Guid? userId, int page, int pageSize) : base(page, pageSize)
    {
        UserId = userId;
    }

    public Guid? UserId { get; set; }
}
