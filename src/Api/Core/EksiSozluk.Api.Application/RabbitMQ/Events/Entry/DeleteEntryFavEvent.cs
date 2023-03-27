namespace EksiSozluk.Api.Application.RabbitMQ.Events.Entry;

public class DeleteEntryFavEvent
{
    public Guid UserId { get; set; }
    public Guid EntryId { get; set; }
}