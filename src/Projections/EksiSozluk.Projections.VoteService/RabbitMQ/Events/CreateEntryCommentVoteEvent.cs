using EksiSozluk.Projections.VoteService.Enums;

public class CreateEntryCommentVoteEvent
{
    public Guid EntryCommentId { get; set; }

    public VoteType VoteType { get; set; }

    public Guid CreatedBy { get; set; }
}