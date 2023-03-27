using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace EksiSozluk.Api.Infrastructure.Persistence.Extensions;

public static class RabbitMQExtensions
{
    public static EventingBasicConsumer EnsureExchange(this EventingBasicConsumer consumer, string exchangeName,
        string exchangeType = RabbitMQ.Constants.DefaultExchangeType)
    {
        consumer.Model.ExchangeDeclare(exchangeName,exchangeType,false,false);
        return consumer;
    }
    
    public static EventingBasicConsumer EnsureQueue(this EventingBasicConsumer consumer, string queueName,string exchangeName)
    {
        consumer.Model.QueueDeclare(queueName, false, false,false,null);
        consumer.Model.QueueBind(queueName,exchangeName,queueName);
        return consumer;
    }  
}