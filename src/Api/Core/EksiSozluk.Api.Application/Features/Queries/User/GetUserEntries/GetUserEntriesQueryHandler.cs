using EksiSozluk.Api.Application.Features.Queries.User.GetUserDetails;
using MediatR;

namespace EksiSozluk.Api.Application.Features.Queries.User.GetUserEntries;

public class GetUserEntriesQueryHandler : IRequestHandler<GetUserEntriesQueryRequest,GetUserEntriesQueryResponse>
{
    public Task<GetUserEntriesQueryResponse> Handle(GetUserEntriesQueryRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}