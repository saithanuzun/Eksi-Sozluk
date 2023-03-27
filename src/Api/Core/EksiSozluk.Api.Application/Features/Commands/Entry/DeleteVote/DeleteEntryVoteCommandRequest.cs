using EksiSozluk.Api.Domain.Enums;
using MediatR;

namespace EksiSozluk.Api.Application.Features.Commands.Entry.DeleteVote;

public class DeleteEntryVoteCommandRequest : IRequest<DeleteEntryVoteCommandResponse>
{
    public Guid UserId { get; set; }
    public Guid EntryId { get; set; }
    public VoteType Vote { get; set; }
}