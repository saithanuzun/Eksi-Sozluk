using EksiSozluk.Api.Application.Features.Commands.Entry.DeleteVote;
using MediatR;

namespace EksiSozluk.Api.Application.Features.Commands.EntryComment.DeleteFav;

public class DeleteFavCommandRequest : IRequest<DeleteFavCommandResponse>
{
    public Guid EntryCommentId { get; set; }

    public Guid UserId { get; set; }
}