using EksiSozluk.Api.Domain.Enums;
using MediatR;

namespace EksiSozluk.Api.Application.Features.Commands.EntryComment.CreateVote;

public class CreateVoteCommandRequest : IRequest<CreateVoteCommandResponse>
{
    public Guid EntryCommentId { get; set; }
    public Guid UserId { get; set; }
    public VoteType Vote { get; set; }
}