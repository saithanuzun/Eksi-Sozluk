using System.Diagnostics;
using EksiSozluk.Projections.UserService.RabbitMQ;

namespace EksiSozluk.Projections.UserService;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;

    public Worker(ILogger<Worker> logger)
    {
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        
        var service = new Service.UserService();

        RabbitMqService _rabbit = new RabbitMqService();
        
        _rabbit.Receiver<UserEmailChangedEvent>(Constants.UserEmailChangedQueueName,(email) =>
        {
            service.CreateEmailConfirmation(email).GetAwaiter().GetResult();
            Debug.WriteLine("Email confirmed");
        });
        
    }
}