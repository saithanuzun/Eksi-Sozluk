namespace EksiSozluk.Projections.FavoriteService.RabbitMQ.Events;

public class DeleteEntryFavEvent
{
    public Guid EntryId { get; set; }
    public Guid UserId { get; set; }
}