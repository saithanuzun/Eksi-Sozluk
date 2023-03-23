namespace EksiSozluk.Api.Domain.Entities;

public class EmailConfirmation : BaseEntity
{
    public string NewEmailAddress { get; set; }
    public string OldEmailAddress { get; set; }
}