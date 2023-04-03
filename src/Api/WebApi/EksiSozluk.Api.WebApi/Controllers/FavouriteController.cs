using EksiSozluk.Api.Application.Features.Commands.Entry.CreateFav;
using EksiSozluk.Api.Application.Features.Commands.Entry.DeleteFav;
using EksiSozluk.Api.Application.Features.Commands.EntryComment.CreateFav;
using EksiSozluk.Api.Application.Features.Commands.EntryComment.DeleteFav;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EksiSozluk.Api.WebApi.Controllers;

[Authorize]
public class FavouriteController : BaseController
{
    private readonly IMediator _mediator;


    public FavouriteController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [Route("entry/{entryId}")]
    public async Task<IActionResult> CreateEntryFav(Guid entryId)
    {
        var result = await _mediator.Send(new CreateEntryFavCommandRequest
        {
            EntryId = entryId,
            UserId = UserId.Value
        });

        return Ok(result);
    }

    [HttpPost]
    [Route("entrycomment/{entrycommentId}")]
    public async Task<IActionResult> CreateEntryCommentFav(Guid entrycommentId)
    {
        var response = await _mediator.Send(new CreateFavCommandRequest
        {
            EntryCommentId = entrycommentId,
            UserId = UserId.Value
        });

        return Ok(response);
    }


    [HttpPost]
    [Route("deleteentryfav/{entryId}")]
    public async Task<IActionResult> DeleteEntryFav(Guid entryId)
    {
        var response = await _mediator.Send(new DeleteEntryFavCommandRequest
        {
            EntryId = entryId,
            UserId = UserId.Value
        });

        return Ok(response);
    }

    [HttpPost]
    [Route("deleteentrycommentfav/{entrycommentId}")]
    public async Task<IActionResult> DeleteEntryCommentFav(Guid entrycommentId)
    {
        var response = await _mediator.Send(new DeleteFavCommandRequest
        {
            EntryCommentId = entrycommentId,
            UserId = UserId.Value
        });

        return Ok(response);
    }
}