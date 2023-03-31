using EksiSozluk.Api.Domain.Enums;

namespace EksiSozluk.Api.Application.Features.Queries.EntryComment.GetEntryComments;

public class GetEntryCommentsQueryResponse
{
    public Guid Id { get; set; }
    public string Content { get; set; }
    public DateTime CreatedDate { get; set; }
    public string CreatedByUsername { get; set; }
    public bool IsFavorited { get; set; }

    public int FavoritedCount { get; set; }
    public VoteType VoteType { get; set; }
}