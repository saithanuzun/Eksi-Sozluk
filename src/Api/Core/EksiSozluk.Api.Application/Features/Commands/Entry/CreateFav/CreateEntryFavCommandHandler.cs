using System.Text.Json;
using EksiSozluk.Api.Application.Interfaces.RabbitMq;
using EksiSozluk.Api.Application.RabbitMQ;
using EksiSozluk.Api.Application.RabbitMQ.Events.Entry;
using MediatR;

namespace EksiSozluk.Api.Application.Features.Commands.Entry.CreateFav;

public class CreateEntryFavCommandHandler : IRequestHandler<CreateEntryFavCommandRequest, CreateEntryFavCommandResponse>
{
    private readonly IQueueManager _queueManager;

    public CreateEntryFavCommandHandler(IQueueManager queueManager)
    {
        _queueManager = queueManager;
    }


    public async Task<CreateEntryFavCommandResponse> Handle(CreateEntryFavCommandRequest request,
        CancellationToken cancellationToken)
    {
        var createEntryFav = new CreateEntryFavEvent
        {
            EntryId = request.EntryId.Value,
            CreatedBy = request.UserId.Value
        };
        var json = JsonSerializer.Serialize(createEntryFav);

        _queueManager.SendMassageToFavExchange(RabbitMQConstants.CreateEntryFavQueueName, json);


        return new CreateEntryFavCommandResponse { Fav = true };
    }
}