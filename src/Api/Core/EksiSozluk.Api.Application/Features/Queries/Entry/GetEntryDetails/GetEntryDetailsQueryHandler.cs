using EksiSozluk.Api.Application.Interfaces.Repositories;
using MediatR;

namespace EksiSozluk.Api.Application.Features.Queries.Entry.GetEntryDetails;

public class GetEntryDetailsQueryHandler : IRequestHandler<GetEntryDetailsQueryRequest,GetEntryDetailsQueryResponse>
{
    private IEntryRepository _entryRepository;

    public GetEntryDetailsQueryHandler(IEntryRepository entryRepository)
    {
        _entryRepository = entryRepository;
    }

    public Task<GetEntryDetailsQueryResponse> Handle(GetEntryDetailsQueryRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}