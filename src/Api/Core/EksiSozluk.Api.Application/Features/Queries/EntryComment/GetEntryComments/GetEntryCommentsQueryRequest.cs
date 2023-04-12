using EksiSozluk.Api.Application.Pagination;
using MediatR;

namespace EksiSozluk.Api.Application.Features.Queries.EntryComment.GetEntryComments;

public class GetEntryCommentsQueryRequest : BasePagedQuery, IRequest<PagedViewModel<GetEntryCommentsQueryResponse>>
{
    public GetEntryCommentsQueryRequest(int page, int pageSize, Guid entryId, Guid? userId) : base(page, pageSize)
    {
        EntryId = entryId;
        UserId = userId;
    }

    public Guid EntryId { get; set; }
    public Guid? UserId { get; set; }
}