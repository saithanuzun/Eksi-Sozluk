using MediatR;

namespace EksiSozluk.Api.Application.Features.Commands.Entry.CreateFav;

public class CreateEntryFavCommandRequest : IRequest<CreateEntryFavCommandResponse>
{
    public Guid? EntryId { get; set; }

    public Guid? UserId { get; set; }
}