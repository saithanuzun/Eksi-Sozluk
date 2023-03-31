namespace EksiSozluk.Api.Application.RabbitMQ.Events.EntryComment;

public class DeleteEntryCommentVoteEvent
{
    public Guid EntryCommentId { get; set; }

    public Guid UserId { get; set; }
}