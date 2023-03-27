using EksiSozluk.Api.Domain.Enums;
using MediatR;

namespace EksiSozluk.Api.Application.Features.Commands.Entry.CreateVote;

public class CreateEntryVoteCommandRequest : IRequest<CreateEntryVoteCommandResponse>
{
    public Guid EntryId { get; set; }

    public VoteType VoteType { get; set; }

    public Guid UserId { get; set; }
}