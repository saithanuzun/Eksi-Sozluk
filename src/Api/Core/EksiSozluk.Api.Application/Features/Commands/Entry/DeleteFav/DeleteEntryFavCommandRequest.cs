using MediatR;

namespace EksiSozluk.Api.Application.Features.Commands.Entry.DeleteFav;

public class DeleteEntryFavCommandRequest : IRequest<DeleteEntryFavCommandResponse>
{
    public Guid UserId { get; set; }
    public Guid EntryId { get; set; }
}