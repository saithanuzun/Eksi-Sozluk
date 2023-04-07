using EksiSozluk.Projections.UserService.RabbitMQ;

namespace EksiSozluk.Projections.UserService;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly Service.UserService _userService;

    public Worker(ILogger<Worker> logger, Service.UserService userService)
    {
        _logger = logger;
        _userService = userService;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
       
        RabbitMqServiceBuilder.CreateBasicConsumer()
            .EnsureExchange("UserExchange")
            .EnsureQueue(Constants.UserEmailChangedQueueName, "UserExchange")
            .Receive<UserEmailChangedEvent>(user =>
            {
                // DB Insert 

                var confirmationId = _userService.CreateEmailConfirmation(user).GetAwaiter().GetResult();

                // Generate Link


                // Send Email
            })
            .StartConsuming(Constants.UserEmailChangedQueueName);

        
    }
}