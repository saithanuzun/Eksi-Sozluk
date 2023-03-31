using System.Text.Json;
using EksiSozluk.Api.Application.Interfaces.RabbitMq;
using EksiSozluk.Api.Application.RabbitMQ;
using EksiSozluk.Api.Application.RabbitMQ.Events.EntryComment;
using MediatR;

namespace EksiSozluk.Api.Application.Features.Commands.EntryComment.DeleteFav;

public class DeleteFavCommandHandler : IRequestHandler<DeleteFavCommandRequest, DeleteFavCommandResponse>
{
    private readonly IQueueManager _queueManager;

    public DeleteFavCommandHandler(IQueueManager queueManager)
    {
        _queueManager = queueManager;
    }

    public async Task<DeleteFavCommandResponse> Handle(DeleteFavCommandRequest request,
        CancellationToken cancellationToken)
    {
        var obj = new DeleteEntryCommentFavEvent
        {
            EntryCommentId = request.EntryCommentId,
            CreatedBy = request.UserId
        };
        var json = JsonSerializer.Serialize(obj);
        _queueManager.SendMassageToFavExchange(RabbitMQConstants.DeleteEntryCommentFavQueueName, json);

        return new DeleteFavCommandResponse { Deleted = true };
    }
}