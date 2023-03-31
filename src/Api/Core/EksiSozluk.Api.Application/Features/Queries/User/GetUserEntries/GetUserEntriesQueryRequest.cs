using EksiSozluk.Api.Application.Pagination;
using MediatR;

namespace EksiSozluk.Api.Application.Features.Queries.User.GetUserEntries;

public class GetUserEntriesQueryRequest : BasePagedQuery, IRequest<PagedViewModel<GetUserEntriesQueryResponse>>
{
    public GetUserEntriesQueryRequest(Guid? userId, string? username, int page = 1, int pageSize = 10) : base(page,
        pageSize)
    {
        UserId = userId;
        Username = username;
    }

    public Guid? UserId { get; set; }
    public string? Username { get; set; }
}