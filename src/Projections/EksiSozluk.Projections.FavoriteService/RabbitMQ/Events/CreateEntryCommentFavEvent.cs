namespace EksiSozluk.Projections.FavoriteService.RabbitMQ.Events;

public class CreateEntryCommentFavEvent
{
    public Guid EntryCommentId { get; set; }
    public Guid UserId { get; set; }
}