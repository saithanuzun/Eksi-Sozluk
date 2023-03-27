using EksiSozluk.Api.Domain.Enums;

namespace EksiSozluk.Api.Application.RabbitMQ.Events.EntryComment;

public class CreateEntryCommentVoteEvent
{
    public Guid EntryCommentId { get; set; }

    public VoteType VoteType { get; set; }

    public Guid CreatedBy { get; set; }
}