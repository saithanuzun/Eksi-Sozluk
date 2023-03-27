namespace EksiSozluk.Api.Application.Interfaces.RabbitMq;

public interface IQueueManager
{ 
    void SendMassageToExchange(string exchangeName, string exchangeType, string queueName, string obj);
    

}