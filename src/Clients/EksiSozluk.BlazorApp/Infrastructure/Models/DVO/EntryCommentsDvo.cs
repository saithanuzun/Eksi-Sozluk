namespace EksiSozluk.BlazorApp.Infrastructure.Models.DVO;

public class EntryCommentsDvo
{
    public Guid Id { get; set; }

    public string Content { get; set; }

    public DateTime CreatedDate { get; set; }

    public string CreatedByUserName { get; set; }

}