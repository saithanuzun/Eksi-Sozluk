using System.Text.Json;
using EksiSozluk.Api.Application.Features.Commands.Entry.CreateFav;
using EksiSozluk.Api.Application.Interfaces.RabbitMq;
using EksiSozluk.Api.Application.RabbitMQ;
using EksiSozluk.Api.Application.RabbitMQ.Events.EntryComment;
using MediatR;

namespace EksiSozluk.Api.Application.Features.Commands.EntryComment.CreateVote;

public class CreateVoteCommandHandler : IRequestHandler<CreateVoteCommandRequest,CreateVoteCommandResponse>
{
    private IQueueManager _queueManager;

    public CreateVoteCommandHandler(IQueueManager queueManager)
    {
        _queueManager = queueManager;
    }
    public async Task<CreateVoteCommandResponse> Handle(CreateVoteCommandRequest request, CancellationToken cancellationToken)
    {
        var obj = new CreateEntryCommentVoteEvent()
        {
            EntryCommentId = request.EntryCommentId,
            CreatedBy = request.UserId,
            VoteType = request.Vote,
        };
        var json = JsonSerializer.Serialize(obj);
        _queueManager.SendMassageToVoteExchange(RabbitMQConstants.CreateEntryCommentVoteQueueName,json);

        return new CreateVoteCommandResponse() {Created = true};
    }
}