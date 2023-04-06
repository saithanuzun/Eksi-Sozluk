using System.Text.Json;
using EksiSozluk.Api.Application.Interfaces.RabbitMq;
using EksiSozluk.Api.Application.RabbitMQ;
using EksiSozluk.Api.Application.RabbitMQ.Events.EntryComment;
using MediatR;

namespace EksiSozluk.Api.Application.Features.Commands.EntryComment.CreateFav;

public class CreateFavCommandHandler : IRequestHandler<CreateFavCommandRequest, CreateFavCommandResponse>
{
    private readonly IQueueManager _queueManager;

    public CreateFavCommandHandler(IQueueManager queueManager)
    {
        _queueManager = queueManager;
    }

    public async Task<CreateFavCommandResponse> Handle(CreateFavCommandRequest request,
        CancellationToken cancellationToken)
    {
        var obj = new CreateEntryCommentFavEvent
        {
            UserId = request.UserId,
            EntryCommentId = request.EntryCommentId
        };
        var json = JsonSerializer.Serialize(obj);

        _queueManager.SendMassageToFavExchange(RabbitMQConstants.CreateEntryCommentFavQueueName, json);

        return new CreateFavCommandResponse(){IsCreated = true};
    }
}