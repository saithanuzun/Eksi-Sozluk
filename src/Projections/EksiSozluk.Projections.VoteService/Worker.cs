using EksiSozluk.Projections.VoteService.RabbitMQ;

namespace EksiSozluk.Projections.VoteService;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;


    public Worker(ILogger<Worker> logger)
    {
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var connectionString =
            "USER ID=postgres ; Password=password123;Server=localhost;Port=5432;Database=eksisozluk;Integrated Security=true;Pooling=true";

        var service = new Services.VoteService(connectionString);

        var _rabbit = new RabbitMqService();

        _rabbit.Receiver<CreateEntryVoteEvent>(Constants.CreateEntryVoteQueueName,
            async vote => { await service.CreateEntryVote(vote); });

        _rabbit.Receiver<CreateEntryCommentVoteEvent>(Constants.CreateEntryCommentVoteQueueName,
            async vote => { await service.CreateEntryCommentVote(vote); });

        _rabbit.Receiver<DeleteEntryVoteEvent>(Constants.DeleteEntryVoteQueueName,
            async vote => { await service.DeleteEntryVote(vote.EntryId, vote.UserId); });

        _rabbit.Receiver<DeleteEntryCommentVoteEvent>(Constants.DeleteEntryCommentVoteQueueName,
            async vote => { await service.DeleteEntryCommentVote(vote.EntryCommentId, vote.UserId); });
    }
}