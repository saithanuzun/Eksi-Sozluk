namespace EksiSozluk.Projections.UserService.RabbitMQ;

public class UserEmailChangedEvent
{
    public string OldEmailAddress { get; set; }
    public string NewEmailAddress { get; set; }
}