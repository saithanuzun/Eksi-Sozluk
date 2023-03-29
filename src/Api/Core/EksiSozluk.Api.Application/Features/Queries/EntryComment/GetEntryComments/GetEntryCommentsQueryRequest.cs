using EksiSozluk.Api.Application.Features.Queries.Entry.GetEntries;
using EksiSozluk.Api.Application.Pagination;
using MediatR;

namespace EksiSozluk.Api.Application.Features.Queries.EntryComment.GetEntryComments;

public class GetEntryCommentsQueryRequest : BasePagedQuery, IRequest<PagedViewModel<GetEntryCommentsQueryResponse>>
{

    public Guid EntryId { get; set; }
    public Guid? UserId { get; set; }
    public GetEntryCommentsQueryRequest(int page, int pageSize, Guid entryId, Guid userId) : base(page, pageSize)
    {
        EntryId = entryId;
        UserId = userId;
    }
}