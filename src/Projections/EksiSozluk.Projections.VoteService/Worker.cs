using EksiSozluk.Projections.VoteService.RabbitMQ;

namespace EksiSozluk.Projections.VoteService;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly Services.VoteService _voteService;


    public Worker(ILogger<Worker> logger, Services.VoteService voteService)
    {
        _logger = logger;
        _voteService = voteService;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        
        RabbitMqServiceBuilder
            .CreateBasicConsumer()
            .EnsureExchange(Constants.VoteExchangeName)
            .EnsureQueue(Constants.CreateEntryVoteQueueName, Constants.VoteExchangeName)
            .Receive<CreateEntryVoteEvent>(vote =>
            {
                _voteService.CreateEntryVote(vote).GetAwaiter().GetResult();
                _logger.LogInformation("Create Entry Received EntryId: {0}, VoteType: {1}", vote.EntryId, vote.VoteType);
            })
            .StartConsuming(Constants.CreateEntryVoteQueueName);
        
        RabbitMqServiceBuilder
            .CreateBasicConsumer()
            .EnsureExchange(Constants.VoteExchangeName)
            .EnsureQueue(Constants.DeleteEntryVoteQueueName, Constants.VoteExchangeName)
            .Receive<DeleteEntryVoteEvent>(vote =>
            {
                _voteService.DeleteEntryVote(vote.EntryId, vote.UserId).GetAwaiter().GetResult();
                _logger.LogInformation("Delete Entry Received EntryId: {0}", vote.EntryId);
            })
            .StartConsuming(Constants.DeleteEntryVoteQueueName);


        RabbitMqServiceBuilder
            .CreateBasicConsumer()
            .EnsureExchange(Constants.VoteExchangeName)
            .EnsureQueue(Constants.CreateEntryCommentVoteQueueName, Constants.VoteExchangeName)
            .Receive<CreateEntryCommentVoteEvent>(vote =>
            {
                _voteService.CreateEntryCommentVote(vote).GetAwaiter().GetResult();
                _logger.LogInformation("Create Entry Comment Received EntryCommentId: {0}, VoteType: {1}", vote.EntryCommentId, vote.VoteType);
            })
            .StartConsuming(Constants.CreateEntryCommentVoteQueueName);

        RabbitMqServiceBuilder
            .CreateBasicConsumer()
            .EnsureExchange(Constants.VoteExchangeName)
            .EnsureQueue(Constants.DeleteEntryCommentVoteQueueName, Constants.VoteExchangeName)
            .Receive<DeleteEntryCommentVoteEvent>(vote =>
            {
                _voteService.DeleteEntryCommentVote(vote.EntryCommentId, vote.UserId).GetAwaiter().GetResult();
                _logger.LogInformation("Delete Entry Comment Received EntryCommentId: {0}", vote.EntryCommentId);
            })
            .StartConsuming(Constants.DeleteEntryCommentVoteQueueName);
        
    }
}