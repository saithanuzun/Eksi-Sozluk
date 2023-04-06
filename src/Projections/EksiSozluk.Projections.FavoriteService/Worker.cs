using EksiSozluk.Projections.FavoriteService.RabbitMQ;
using EksiSozluk.Projections.FavoriteService.RabbitMQ.Events;

namespace EksiSozluk.Projections.FavoriteService;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly Services.FavoriteService _favoriteService;

    public Worker(ILogger<Worker> logger, Services.FavoriteService favoriteService)
    {
        _logger = logger;
        _favoriteService = favoriteService;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        RabbitMqServiceBuilder.CreateBasicConsumer()
            .EnsureExchange(Constants.FavExchangeName)
            .EnsureQueue(Constants.CreateEntryFavQueueName, Constants.FavExchangeName)
            .Receive<CreateEntryFavEvent>(fav =>
            {
                _favoriteService.CreateEntryFav(fav).GetAwaiter().GetResult();
                _logger.LogInformation($"Received EntryId {fav.EntryId}");
            })
            .StartConsuming(Constants.CreateEntryFavQueueName);

        RabbitMqServiceBuilder.CreateBasicConsumer()
            .EnsureExchange(Constants.FavExchangeName)
            .EnsureQueue(Constants.DeleteEntryFavQueueName, Constants.FavExchangeName)
            .Receive<DeleteEntryFavEvent>(fav =>
            {
                _favoriteService.DeleteEntryFav(fav).GetAwaiter().GetResult();
                _logger.LogInformation($"Deleted Received EntryId {fav.EntryId}");
            })
            .StartConsuming(Constants.DeleteEntryFavQueueName);


        
        RabbitMqServiceBuilder.CreateBasicConsumer()
            .EnsureExchange(Constants.FavExchangeName)
            .EnsureQueue(Constants.CreateEntryCommentFavQueueName, Constants.FavExchangeName)
            .Receive<CreateEntryCommentFavEvent>(fav =>
            {
                _favoriteService.CreateEntryCommentFav(fav).GetAwaiter().GetResult();
                _logger.LogInformation($"Create EntryComment Received EntryCommentId {fav.EntryCommentId}");
            })
            .StartConsuming(Constants.CreateEntryCommentFavQueueName);


        RabbitMqServiceBuilder.CreateBasicConsumer()
            .EnsureExchange(Constants.FavExchangeName)
            .EnsureQueue(Constants.DeleteEntryCommentFavQueueName, Constants.FavExchangeName)
            .Receive<DeleteEntryCommentFavEvent>(fav =>
            {
                _favoriteService.DeleteEntryCommentFav(fav).GetAwaiter().GetResult();
                _logger.LogInformation($"Deleted Received EntryCommentId {fav.EntryCommentId}");
            })
            .StartConsuming(Constants.DeleteEntryCommentFavQueueName);
        
    }
}