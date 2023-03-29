using EksiSozluk.Api.Application.Features.Commands.Entry.CreateVote;
using EksiSozluk.Api.Application.Features.Commands.Entry.DeleteVote;
using EksiSozluk.Api.Application.Features.Commands.EntryComment.CreateVote;
using EksiSozluk.Api.Application.Features.Commands.EntryComment.DeleteVote;
using EksiSozluk.Api.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EksiSozluk.Api.WebApi.Controllers;

public class VoteController : BaseController
{
    private IMediator _mediator;

    public VoteController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [Route("Entry/{EntryId}")]
    public async Task<IActionResult> CreateEntryVote(Guid EntryId , VoteType type=VoteType.UpVote)
    {
        var response = await _mediator.Send(new CreateEntryVoteCommandRequest()
            { EntryId = EntryId, UserId = UserId.Value, VoteType = type });
        return Ok(response);
    }
    
    [HttpPost]
    [Route("EntryComment/{entryCommentId}")]
    public async Task<IActionResult> CreateEntryCommentVote(Guid entryCommentId, VoteType voteType = VoteType.UpVote)
    {
        var result = await _mediator.Send(new CreateVoteCommandRequest()
        {
            EntryCommentId = entryCommentId,
            UserId = UserId.Value,
            Vote = voteType,
        });

        return Ok(result);
    }
    [HttpPost]
    [Route("DeleteEntryVote/{entryId}")]
    public async Task<IActionResult> DeleteEntryVote(Guid entryId)
    {
        await _mediator.Send(new DeleteEntryVoteCommandRequest()
        {
            EntryId = entryId,
            UserId = UserId.Value,
        });

        return Ok();
    }

    [HttpPost]
    [Route("DeleteEntryCommentVote/{entryId}")]
    public async Task<IActionResult> DeleteEntryCommentVote(Guid entryCommentId)
    {
        await _mediator.Send(new DeleteVoteCommandRequest()
        {
            EntryCommentId = entryCommentId,
            UserId = UserId.Value,
        });

        return Ok();
    }
}