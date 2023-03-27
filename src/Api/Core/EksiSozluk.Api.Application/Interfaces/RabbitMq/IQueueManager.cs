namespace EksiSozluk.Api.Application.Interfaces.RabbitMq;

public interface IQueueManager
{ 
    void SendMassageToUserExchange(string queueName, string obj);
    void SendMassageToFavExchange(string queueName, string obj);
    void SendMassageToVoteExchange(string queueName, string obj);
}