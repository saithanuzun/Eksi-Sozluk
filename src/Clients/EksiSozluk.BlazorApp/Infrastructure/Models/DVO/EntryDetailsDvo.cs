using EksiSozluk.BlazorApp.Infrastructure.Models.Enums;

namespace EksiSozluk.BlazorApp.Infrastructure.Models.DVO;

public class EntryDetailsDvo
{
    public Guid Id { get; set; }

    public string Subject { get; set; }
    public string Content { get; set; }

    public DateTime CreatedDate { get; set; }

    public string CreatedByUserName { get; set; }
    public VoteType VoteType { get; set; }
    public bool IsFavorited { get; set; }

    public int FavoritedCount { get; set; }

}