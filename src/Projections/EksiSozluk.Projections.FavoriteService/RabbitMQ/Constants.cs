namespace EksiSozluk.Projections.FavoriteService.RabbitMQ;

public class Constants
{
    public const string HostName = "localhost";
    
    public const string FavExchangeName = "FavExchange";
    public const string CreateEntryFavQueueName = "CreateEntryFavQueue";
    public const string CreateEntryCommentFavQueueName = "CreateEntryCommentFavQueue";

    public const string DeleteEntryFavQueueName = "DeleteEntryFavQueue";
    public const string DeleteEntryCommentFavQueueName = "DeleteEntryCommentFavQueue";
}