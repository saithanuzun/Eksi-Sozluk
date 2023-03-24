using EksiSozluk.Api.Domain.Enums;

namespace EksiSozluk.Api.Domain.Entities;

public class EntryVote : BaseEntity
{
    public Guid EntryId { get; set; }
    public VoteType VoteType { get; set; }
    public Guid CreatedById { get; set; }

    public virtual Entry Entry { get; set; }
}