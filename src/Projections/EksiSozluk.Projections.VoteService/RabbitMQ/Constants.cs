namespace EksiSozluk.Projections.VoteService.RabbitMQ;

public class Constants
{
    public const string HostName = "localhost";
    
    public const string VoteExchangeName = "VoteExchange";

    
    public const string CreateEntryVoteQueueName = "CreateEntryVoteQueue";
    public const string DeleteEntryVoteQueueName = "DeleteEntryVoteQueue";

    public const string CreateEntryCommentVoteQueueName = "CreateEntryCommentVoteQueue";
    public const string DeleteEntryCommentVoteQueueName = "DeleteEntryCommentVoteQueue";
}