using MediatR;

namespace EksiSozluk.Api.Application.Features.Commands.EntryComment.Create;

public class CreateEntryCommentCommandRequest : IRequest<CreateEntryCommentCommandResponse>
{
    public Guid? EntryId { get; set; }

    public string Content { get; set; }

    public Guid? UserId { get; set; }

}