namespace EksiSozluk.Api.Application.RabbitMQ;

public class RabbitMQConstants
{
    public const string UserEmailChangedQueueName = "UserEmailChangedQueue";
    
    public const string CreateEntryFavQueueName = "CreateEntryFavQueue";
    public const string DeleteEntryFavQueueName = "DeleteEntryFavQueue";
    
    public const string CreateEntryCommentFavQueueName = "CreateEntryCommentFavQueue";
    public const string DeleteEntryCommentFavQueueName = "DeleteEntryCommentFavQueue";

    public const string CreateEntryVoteQueueName = "CreateEntryVoteQueue";
    public const string DeleteEntryVoteQueueName = "DeleteEntryVoteQueue";
    
    public const string CreateEntryCommentVoteQueueName = "CreateEntryCommentVoteQueue";
    public const string DeleteEntryCommentVoteQueueName = "DeleteEntryCommentVoteQueue";

}