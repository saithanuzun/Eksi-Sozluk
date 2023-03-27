using MediatR;

namespace EksiSozluk.Api.Application.Features.Commands.Entry.Create;

public class CreateEntryCommandRequest : IRequest<CreateEntryCommandResponse>
{
    public string Subject { get; set; }

    public string Content { get; set; }

    public Guid? CreatedById { get; set; }

}