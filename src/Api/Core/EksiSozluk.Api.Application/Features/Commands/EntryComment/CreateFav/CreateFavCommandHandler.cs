using System.Text.Json;
using EksiSozluk.Api.Application.Features.Commands.Entry.Create;
using EksiSozluk.Api.Application.Interfaces.RabbitMq;
using EksiSozluk.Api.Application.RabbitMQ;
using EksiSozluk.Api.Application.RabbitMQ.Events.EntryComment;
using MediatR;

namespace EksiSozluk.Api.Application.Features.Commands.EntryComment.CreateFav;

public class CreateFavCommandHandler : IRequestHandler<CreateFavCommandRequest,CreateFavCommandResponse>
{
    private IQueueManager _queueManager;

    public CreateFavCommandHandler(IQueueManager queueManager)
    {
        _queueManager = queueManager;
    }

    public async Task<CreateFavCommandResponse> Handle(CreateFavCommandRequest request, CancellationToken cancellationToken)
    {
        var obj = new CreateEntryCommentFavEvent()
        {
            UserId = request.UserId,
            EntryCommentId = request.EntryCommentId,
        };
        var json = JsonSerializer.Serialize(obj);
        _queueManager.SendMassageToExchange(RabbitMQConstants.FavExchangeName,
            RabbitMQConstants.DefaultExchangeType,
            RabbitMQConstants.CreateEntryCommentFavQueueName
            ,json);
        return new CreateFavCommandResponse() { };
    }
}