using System.Text.Json;
using EksiSozluk.Api.Application.Features.Commands.Entry.DeleteFav;
using EksiSozluk.Api.Application.Features.Commands.EntryComment.DeleteFav;
using EksiSozluk.Api.Application.Interfaces.RabbitMq;
using EksiSozluk.Api.Application.RabbitMQ;
using EksiSozluk.Api.Application.RabbitMQ.Events.EntryComment;
using MediatR;

namespace EksiSozluk.Api.Application.Features.Commands.EntryComment.DeleteVote;

public class DeleteVoteCommandHandler : IRequestHandler<DeleteVoteCommandRequest,DeleteVoteCommandResponse>
{
    private IQueueManager _queueManager;

    public DeleteVoteCommandHandler(IQueueManager queueManager)
    {
        _queueManager = queueManager;
    }

    public async Task<DeleteVoteCommandResponse> Handle(DeleteVoteCommandRequest request, CancellationToken cancellationToken)
    {
        var obj = new DeleteEntryCommentVoteEvent()
        {
            EntryCommentId = request.EntryCommentId,
            UserId = request.UserId,
        };
        var json = JsonSerializer.Serialize(obj);
        _queueManager.SendMassageToVoteExchange(RabbitMQConstants.DeleteEntryCommentVoteQueueName,json);

        return new DeleteVoteCommandResponse() { Deleted = true };
    }
}