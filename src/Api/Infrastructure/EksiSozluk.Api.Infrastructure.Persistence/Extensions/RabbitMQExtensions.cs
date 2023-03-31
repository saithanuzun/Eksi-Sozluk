using System.Text;
using System.Text.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Constants = EksiSozluk.Api.Infrastructure.Persistence.RabbitMQ.Constants;

namespace EksiSozluk.Api.Infrastructure.Persistence.Extensions;

public static class RabbitMQExtensions
{
    public static EventingBasicConsumer EnsureExchange(this EventingBasicConsumer consumer, string exchangeName,
        string exchangeType = Constants.DefaultExchangeType)
    {
        consumer.Model.ExchangeDeclare(exchangeName, exchangeType);
        return consumer;
    }

    public static EventingBasicConsumer EnsureQueue(this EventingBasicConsumer consumer, string queueName,
        string exchangeName)
    {
        consumer.Model.QueueDeclare(queueName, false, false, false, null);
        consumer.Model.QueueBind(queueName, exchangeName, queueName);
        return consumer;
    }

    public static EventingBasicConsumer Receive<T>(this EventingBasicConsumer consumer, Action<T> act)
    {
        consumer.Received += (m, eventArgs) =>
        {
            var body = eventArgs.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);

            var model = JsonSerializer.Deserialize<T>(message);

            act(model);
            consumer.Model.BasicAck(eventArgs.DeliveryTag, false);
        };

        return consumer;
    }

    public static EventingBasicConsumer StartConsuming(this EventingBasicConsumer consumer, string queueName)
    {
        consumer.Model.BasicConsume(queueName,
            false,
            consumer);

        return consumer;
    }
}