using System.Text;
using System.Text.Json;
using EksiSozluk.Api.Application.Interfaces.RabbitMq;
using EksiSozluk.Api.Infrastructure.Persistence.Extensions;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace EksiSozluk.Api.Infrastructure.Persistence.RabbitMQ;
public  class QueueManager : IQueueManager
{
    public  void SendMassageToExchange(string exchangeName, string exchangeType, string queueName ,string  obj)
    {
        var channel = CreateBasicConsumer()
            .EnsureExchange(exchangeName:exchangeName,exchangeType: exchangeType)
            .EnsureQueue(queueName,exchangeName)
            .Model;
        
        var body = Encoding.UTF8.GetBytes(obj);
        
        channel.BasicPublish(exchangeName,queueName,null,body);
        
    }

    private  EventingBasicConsumer CreateBasicConsumer()
    {
        var factory = new ConnectionFactory() { HostName = Constants.RabbitMqHost };
        var connection = factory.CreateConnection();
        var channel = connection.CreateModel();

        return new EventingBasicConsumer(channel);
    }

      
}