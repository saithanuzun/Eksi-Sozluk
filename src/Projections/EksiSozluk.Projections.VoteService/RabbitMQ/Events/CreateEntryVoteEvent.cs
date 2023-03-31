using EksiSozluk.Projections.VoteService.Enums;

public class CreateEntryVoteEvent
{
    public Guid EntryId { get; set; }

    public VoteType VoteType { get; set; }

    public Guid UserId { get; set; }
}