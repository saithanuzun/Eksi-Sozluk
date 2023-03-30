using System.Text;
using System.Text.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace EksiSozluk.Projections.VoteService.RabbitMQ;

public class RabbitMqService
{
    public void Receiver<T>(string queueName , Action<T> act)
    {
        var factory = new ConnectionFactory() { HostName = "localhost" };
        var connection = factory.CreateConnection();
        var channel = connection.CreateModel();

        channel.QueueDeclare(queueName, false, false, false, null);
        
        var consumer = new EventingBasicConsumer(channel);

        consumer.Received += async (model, eventArgs) =>
        {
            var body = eventArgs.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            var obj = JsonSerializer.Deserialize<T>(message);
            act(obj);
            consumer.Model.BasicAck(eventArgs.DeliveryTag,false);
        };
        
        channel.BasicConsume(queue: queueName,
            autoAck: true,
            consumer: consumer);
    }
}