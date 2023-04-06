namespace EksiSozluk.Projections.FavoriteService.RabbitMQ.Events;

public class CreateEntryFavEvent
{
    public Guid EntryId { get; set; }
    public Guid UserId { get; set; }
}