using System.Text.Json;
using EksiSozluk.Api.Application.Interfaces.RabbitMq;
using EksiSozluk.Api.Application.RabbitMQ;
using EksiSozluk.Api.Application.RabbitMQ.Events.Entry;
using MediatR;

namespace EksiSozluk.Api.Application.Features.Commands.Entry.DeleteFav;

public class DeleteEntryFavCommandHandler : IRequestHandler<DeleteEntryFavCommandRequest,DeleteEntryFavCommandResponse>
{
    private IQueueManager _queueManager;

    public DeleteEntryFavCommandHandler(IQueueManager queueManager)
    {
        _queueManager = queueManager;
    }

    public async Task<DeleteEntryFavCommandResponse> Handle(DeleteEntryFavCommandRequest request, CancellationToken cancellationToken)
    {
        var obj = new DeleteEntryFavEvent()
        {
            UserId = request.UserId,
            EntryId = request.EntryId,
        };
        var json = JsonSerializer.Serialize(obj);
        _queueManager.SendMassageToExchange(RabbitMQConstants.FavExchangeName,
            RabbitMQConstants.DefaultExchangeType,
            RabbitMQConstants.DeleteEntryFavQueueName,
            obj:json);
        
        return new DeleteEntryFavCommandResponse(){Deleted = true};
    }
}