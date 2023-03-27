using System.Text.Json;
using EksiSozluk.Api.Application.RabbitMQ;
using EksiSozluk.Api.Application.RabbitMQ.Events.Entry;
using MediatR;

namespace EksiSozluk.Api.Application.Features.Commands.Entry.DeleteFav;

public class DeleteEntryFavCommandRequest : IRequest<DeleteEntryFavCommandResponse>
{
    public Guid UserId { get; set; }
    public Guid EntryId { get; set; }
}