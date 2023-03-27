using MediatR;

namespace EksiSozluk.Api.Application.Features.Commands.EntryComment.CreateFav;

public class CreateFavCommandRequest : IRequest<CreateFavCommandResponse>
{
    public Guid EntryCommentId { get; set; }

    public Guid UserId { get; set; }
}