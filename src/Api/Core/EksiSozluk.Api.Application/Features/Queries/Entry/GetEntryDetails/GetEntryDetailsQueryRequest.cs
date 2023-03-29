using MediatR;

namespace EksiSozluk.Api.Application.Features.Queries.Entry.GetEntryDetails;

public class GetEntryDetailsQueryRequest : IRequest<GetEntryDetailsQueryResponse>
{
    public Guid EntryId { get; set; }
    public Guid? UserId { get; set; }
}