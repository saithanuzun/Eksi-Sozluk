using System.Text;
using EksiSozluk.Api.Application.Interfaces.RabbitMq;
using EksiSozluk.Api.Infrastructure.Persistence.Extensions;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace EksiSozluk.Api.Infrastructure.Persistence.RabbitMQ;

public class QueueManager : IQueueManager
{
    public void SendMassageToUserExchange(string queueName, string obj)
    {
        SendMassageToExchange(Constants.UserExchangeName, Constants.DefaultExchangeType, queueName, obj);
    }

    public void SendMassageToFavExchange(string queueName, string obj)
    {
        SendMassageToExchange(Constants.FavExchangeName, Constants.DefaultExchangeType, queueName, obj);
    }

    public void SendMassageToVoteExchange(string queueName, string obj)
    {
        SendMassageToExchange(Constants.VoteExchangeName, Constants.DefaultExchangeType, queueName, obj);
    }

    private void SendMassageToExchange(string exchangeName, string exchangeType, string queueName, string obj)
    {
        var channel = CreateBasicConsumer()
            .EnsureExchange(exchangeName, exchangeType)
            .EnsureQueue(queueName, exchangeName)
            .Model;

        var body = Encoding.UTF8.GetBytes(obj);
        channel.BasicPublish(exchangeName, queueName, null, body);
    }

    private EventingBasicConsumer CreateBasicConsumer()
    {
        var factory = new ConnectionFactory { HostName = Constants.RabbitMqHost };
        var connection = factory.CreateConnection();
        var channel = connection.CreateModel();

        return new EventingBasicConsumer(channel);
    }
}