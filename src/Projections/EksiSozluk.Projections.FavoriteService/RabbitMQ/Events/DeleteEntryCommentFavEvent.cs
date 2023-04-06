namespace EksiSozluk.Projections.FavoriteService.RabbitMQ.Events;

public class DeleteEntryCommentFavEvent
{
    public Guid EntryCommentId { get; set; }
    public Guid UserId { get; set; }
}