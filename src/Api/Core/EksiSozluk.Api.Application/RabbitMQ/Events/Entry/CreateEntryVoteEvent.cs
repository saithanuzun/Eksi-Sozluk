using EksiSozluk.Api.Domain.Enums;

namespace EksiSozluk.Api.Application.RabbitMQ.Events.Entry;

public class CreateEntryVoteEvent
{
    public Guid EntryId { get; set; }

    public VoteType  VoteType { get; set; }

    public Guid UserId { get; set; }
}