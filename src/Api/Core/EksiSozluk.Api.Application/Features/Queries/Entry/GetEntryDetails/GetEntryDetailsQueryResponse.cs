using EksiSozluk.Api.Domain.Enums;

namespace EksiSozluk.Api.Application.Features.Queries.Entry.GetEntryDetails;

public class GetEntryDetailsQueryResponse
{
    public Guid? Id { get; set; }

    public string Subject { get; set; }
    public string Content { get; set; }

    public DateTime CreatedDate { get; set; }

    public string CreatedByUserName { get; set; }

    public bool IsFavorited { get; set; }

    public int FavoritedCount { get; set; }

    public VoteType VoteType { get; set; }
}