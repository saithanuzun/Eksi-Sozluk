using System.Text.Json;
using EksiSozluk.Api.Application.Interfaces.RabbitMq;
using EksiSozluk.Api.Application.RabbitMQ;
using EksiSozluk.Api.Application.RabbitMQ.Events.Entry;
using MediatR;

namespace EksiSozluk.Api.Application.Features.Commands.Entry.DeleteVote;

public class DeleteEntryVoteCommandHandler : IRequestHandler<DeleteEntryVoteCommandRequest,DeleteEntryVoteCommandResponse>
{
    private IQueueManager _queueManager;

    public DeleteEntryVoteCommandHandler(IQueueManager queueManager)
    {
        _queueManager = queueManager;
    }

    public async Task<DeleteEntryVoteCommandResponse> Handle(DeleteEntryVoteCommandRequest request, CancellationToken cancellationToken)
    {
        var obj = new DeleteEntryVoteEvent()
        {
            UserId = request.UserId,
            EntryId = request.EntryId,
        };
        var json = JsonSerializer.Serialize(obj);
        
        _queueManager.SendMassageToExchange(RabbitMQConstants.VoteExchangeName,
            RabbitMQConstants.DefaultExchangeType,
            RabbitMQConstants.DeleteEntryVoteQueueName
            ,obj:json);
        
        return new DeleteEntryVoteCommandResponse() { Deleted = true};
    }
}