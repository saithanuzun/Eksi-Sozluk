namespace EksiSozluk.Api.Application.RabbitMQ.Events.Entry;

public class CreateEntryFavEvent
{
    public Guid EntryId { get; set; }

    public Guid CreatedBy { get; set; }
}