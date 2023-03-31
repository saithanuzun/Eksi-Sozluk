using System.Text.Json;
using EksiSozluk.Api.Application.Interfaces.RabbitMq;
using EksiSozluk.Api.Application.RabbitMQ;
using EksiSozluk.Api.Application.RabbitMQ.Events.Entry;
using MediatR;

namespace EksiSozluk.Api.Application.Features.Commands.Entry.CreateVote;

public class
    CreateEntryVoteCommandHandler : IRequestHandler<CreateEntryVoteCommandRequest, CreateEntryVoteCommandResponse>
{
    private readonly IQueueManager _queueManager;

    public CreateEntryVoteCommandHandler(IQueueManager queueManager)
    {
        _queueManager = queueManager;
    }

    public async Task<CreateEntryVoteCommandResponse> Handle(CreateEntryVoteCommandRequest request,
        CancellationToken cancellationToken)
    {
        var obj = new CreateEntryVoteEvent
        {
            UserId = request.UserId,
            EntryId = request.EntryId,
            VoteType = request.VoteType
        };
        var json = JsonSerializer.Serialize(obj);

        _queueManager.SendMassageToVoteExchange(RabbitMQConstants.CreateEntryVoteQueueName, json);


        return new CreateEntryVoteCommandResponse { Vote = true };
    }
}