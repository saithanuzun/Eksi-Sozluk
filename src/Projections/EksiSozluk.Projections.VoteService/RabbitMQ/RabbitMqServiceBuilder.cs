using System.Text;
using System.Text.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace EksiSozluk.Projections.VoteService.RabbitMQ;

public static class RabbitMqServiceBuilder
{
    public static EventingBasicConsumer CreateBasicConsumer()
    {
        var factory = new ConnectionFactory() { HostName = Constants.HostName };
        var connection = factory.CreateConnection();
        var channel = connection.CreateModel();

        return new EventingBasicConsumer(channel);
    }

    public static EventingBasicConsumer EnsureExchange(this EventingBasicConsumer consumer,
        string exchangeName,
        string exchangeType = "direct")
    {
        consumer.Model.ExchangeDeclare(exchange: exchangeName,
            type: exchangeType,
            durable: false,
            autoDelete: false);
        return consumer;
    }

    public static EventingBasicConsumer EnsureQueue(this EventingBasicConsumer consumer,
        string queueName,
        string exchangeName)
    {
        consumer.Model.QueueDeclare(queue: queueName,
            durable: false,
            exclusive: false,
            autoDelete: false,
            null);

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
        consumer.Model.BasicConsume(queue: queueName,
            autoAck: false,
            consumer: consumer);

        return consumer;
    }
}