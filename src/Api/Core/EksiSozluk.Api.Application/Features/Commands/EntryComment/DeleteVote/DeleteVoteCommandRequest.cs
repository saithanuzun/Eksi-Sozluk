using MediatR;

namespace EksiSozluk.Api.Application.Features.Commands.EntryComment.DeleteVote;

public class DeleteVoteCommandRequest : IRequest<DeleteVoteCommandResponse>
{
    public Guid EntryCommentId { get; set; }
    public Guid UserId { get; set; }
}